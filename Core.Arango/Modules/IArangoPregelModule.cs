﻿using System.Threading;
using System.Threading.Tasks;
using Core.Arango.Protocol;

namespace Core.Arango.Modules
{
    /// <summary>
    ///     Arango Pregel Control
    /// </summary>
    public interface IArangoPregelModule
    {
        /// <summary>
        ///     Start the execution of a Pregel algorithm
        /// </summary>
        ValueTask<string> StartJobAsync(ArangoHandle database, ArangoPregel job,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Get the status of a Pregel execution
        /// </summary>
        ValueTask<ArangoPregelStatus> GetJobStatusAsync(ArangoHandle database, string id,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Cancel an ongoing Pregel execution
        /// </summary>
        ValueTask DeleteJobAsync(ArangoHandle database, string id, CancellationToken cancellationToken = default);
    }
}