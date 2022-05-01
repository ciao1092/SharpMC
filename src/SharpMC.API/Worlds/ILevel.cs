﻿using System;
using System.Collections.Generic;
using SharpMC.API.Chunks;
using SharpMC.API.Entities;
using SharpMC.API.Enums;
using SharpMC.API.Net;
using SharpMC.API.Utils;

namespace SharpMC.API.Worlds
{
    public interface ILevel
    {
        void SaveChunks();

        void CalculateTps(IPlayer player);

        int TimeToRain { get; set; }

        int WorldTime { get; set; }

        int PlayerCount { get; }

        long GameTick { get; }

        ILocation SpawnPoint { get; }

        GameMode DefaultGameMode { get; }

        IEnumerable<IPlayer> GetPlayers();

        void RelayBroadcast(INetPacket packet);
        void RelayBroadcast(IPlayer[] players, INetPacket packet);

        void AddPlayer(IPlayer player, bool spawn);
        void RemovePlayer(IPlayer player);

        IEnumerable<(byte[], ChunkCoordinates)> GenerateChunks(
            IPlayer player, ChunkCoordinates chunkPosition,
            Dictionary<Tuple<int, int>, byte[]> chunksUsed, double radius);

        void DespawnFromAll(IPlayer player);
    }
}