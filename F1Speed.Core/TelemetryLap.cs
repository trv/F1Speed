﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;
using F1Speed.Core.Repositories;

namespace F1Speed.Core
{
    [Serializable]
    public class TelemetryLap : ISerializable, ISectorTiming
    {
        private static object syncLock = new object();

        public TelemetryLap()
        {
            
        }

        public TelemetryLap(Circuit circuit, string lapType)
        {
            Packets = new List<TelemetryPacket>();
            Circuit = circuit;
            LapType = lapType;
        }

        public Circuit Circuit { get; set; }

        public TelemetryLap(SerializationInfo info, StreamingContext context)
        {
            var trackLength = info.GetValue<float>("LapTrackLength");

            Packets = info.GetValue<List<TelemetryPacket>>("Packets");
            Circuit = CircuitRepository.GetByTrackLength(trackLength);
            LapType = info.GetValue<string>("LapType");
            try
            {
                _hasFinished = info.GetValue<bool>("HasFinished");
            }
            catch
            {
                _hasFinished = true;
            }
        }

        private List<TelemetryPacket> _packets;

        [XmlArray("Packets"), XmlArrayItem("Packet", typeof (TelemetryPacket))] 
        public List<TelemetryPacket> Packets 
        {
            get { return _packets; }
            set { _packets = value; }
        }

        public string CircuitName 
        {
            get { return Circuit.Name; }        
        }

        private string _lapType;
        public string LapType 
        {
            get { return _lapType;  }
            set { _lapType = value; }
        }
        
        public void AddPacket(TelemetryPacket packet)
        {
            lock (syncLock)
            {
                Packets.Add(packet);
                //while (_packets.Any() && _packets.First().Distance < 0)
                //    _packets.Remove(_packets.First());
            }
        }

        public int LapNumber
        {
            get
            {
                lock (syncLock)
                {
                    if (!Packets.Any())
                        return 0;

                    return (int) Packets.Last().Lap;
                }
            }
        }

        public float LapTime
        {
            get
            {
                lock (syncLock)
                {
                    return !Packets.Any() ? 0f : Packets.Last().LapTime;
                }
            }
        }

        public float Sector1Time
        {
            get
            {
                lock (syncLock)
                {
                    if (!Packets.Any())
                    {
                        return 0f;
                    }
                    if (Math.Abs(Packets.Last().TimeSector1 - 0) < 0.0001)
                    {
                        return Packets.Last().LapTime;
                    }
                    return Packets.Last().TimeSector1;
                }
            }
        }

        public float Sector2Time
        {
            get
            {
                lock (syncLock)
                {
                    if (!Packets.Any() || Math.Abs(Packets.Last().TimeSector1 - 0) < 0.0001)
                    {
                        return 0f;
                    }
                    if (Math.Abs(Packets.Last().TimeSector2 - 0) < 0.0001)
                    {
                        return Packets.Last().LapTime - Sector1Time;
                    }
                    return Packets.Last().TimeSector2;
                }
            }
        }

        public float Sector3Time
        {
            get
            {
                lock (syncLock)
                {
                    if (!Packets.Any() || Math.Abs(Packets.Last().TimeSector2 - 0) < 0.0001)
                    {
                        return 0f;
                    }
                    return Packets.Last().LapTime - Packets.Last().TimeSector2 - Packets.Last().TimeSector1;
                }
            }
        }

        public bool IsFirstPacketStartLine 
        {
            get
            {
                const float cutoff = (1000 / 60000f) + 0.001f;

                lock (syncLock)
                {
                    if (!Packets.Any())
                        return false;
                    var first = Packets.First();
                    return first.LapTime >= 0f && first.LapTime < cutoff;
                }
            }
        }

        public int CurrentSector
        {
            get
            {
                lock (syncLock)
                {
                    if (Packets.Count == 0)
                        return 0;
                    return ((int) Packets.Last().Sector) + 1;
                }
            }
        }

        private bool _hasFinished;
        public bool HasLapFinished
        {
            get { return _hasFinished;  }            
        }
        
        public TelemetryPacket GetPacketClosestTo(TelemetryPacket packet)
        {
            lock (syncLock)
            {
                if (!Packets.Any())
                    return packet;

                var closestPackets = Packets.OrderBy(p => Math.Abs(p.LapDistance - packet.LapDistance)).Take(10);

                return closestPackets.First();
            }
        }
        
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            float lapTrackLength = ((int)(Circuit.TrackLength*1000))/1000f;
            
            info.AddValue("LapTrackLength", lapTrackLength);
            info.AddValue("LapType", _lapType);
            info.AddValue("Packets", _packets);
            info.AddValue("HasFinished", _hasFinished);            
        }

        public bool IsOutLap
        {
            // An outlap can either be less than 0 or less than 1
            get { return Packets.All(c => c.Distance < 1 && Math.Abs(c.LapTime - 0) < Constants.Epsilon); }          
        }

        public bool IsCompleteLap
        {
            get { return IsFirstPacketStartLine && HasLapFinished; } 
        }

        public void MarkLapCompleted()
        {
            _hasFinished = true;
        }

        public float Distance 
        { 
            get
            {
                lock (syncLock)
                {
                    if (!Packets.Any())
                        return 0f;
                    return Packets.Last().Distance;
                }
            }
        }
    }
}
