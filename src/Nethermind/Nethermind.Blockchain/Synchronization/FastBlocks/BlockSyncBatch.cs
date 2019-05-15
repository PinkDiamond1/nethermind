/*
 * Copyright (c) 2018 Demerzel Solutions Limited
 * This file is part of the Nethermind library.
 *
 * The Nethermind library is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * The Nethermind library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with the Nethermind. If not, see <http://www.gnu.org/licenses/>.
 */

using Nethermind.Dirichlet.Numerics;

namespace Nethermind.Blockchain.Synchronization.FastBlocks
{
    public class BlockSyncBatch
    {
        public bool IsSpecialWaitBatch { get; set; }
        public bool IsReorgBatch { get; set; }
        public HeadersSyncBatch HeadersSyncBatch { get; set; }
        public BodiesSyncBatch BodiesSyncBatch { get; set; }
        public SyncPeerAllocation AssignedPeer { get; set; }

        public UInt256? MinTotalDifficulty { get; set; }

        public override string ToString()
        {
            return HeadersSyncBatch == null ? $"BODIES {BodiesSyncBatch.Request.Length}" : $"HEADERS [{HeadersSyncBatch.StartNumber}, {HeadersSyncBatch.StartNumber + HeadersSyncBatch.RequestSize - 1}]";
        }

        public static BlockSyncBatch SpecialWait = new BlockSyncBatch() {IsSpecialWaitBatch = true};
    }
}