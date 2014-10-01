﻿namespace King.Mapper.Data
{
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;

    #region ILoader
    /// <summary>
    /// Loader interface to enable mocking frameworks for unit testing
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public interface ILoader<T>
    {
        #region IDbCommand
        /// <summary>
        /// Generate Models from Database Command
        /// </summary>
        /// <param name="cmd">Command</param>
        /// <param name="action">Action</param>
        /// <returns>Models</returns>
        IEnumerable<T> Models(IDbCommand cmd, ActionFlags action = ActionFlags.Load);


        /// <summary>
        /// Generate Model from Database Command
        /// </summary>
        /// <param name="cmd">Command</param>
        /// <param name="action">Action</param>
        /// <returns>Model</returns>
        T Model(IDbCommand cmd, ActionFlags action = ActionFlags.Load);
        #endregion

        #region IDataReader
        /// <summary>
        /// Generate Models from Data Reader
        /// </summary>
        /// <param name="reader">Data Reader</param>
        /// <param name="action">Action</param>
        /// <returns>Models</returns>
        IEnumerable<T> Models(IDataReader reader, ActionFlags action = ActionFlags.Load);

        /// <summary>
        /// Generate Model from Data Reader
        /// </summary>
        /// <param name="reader">Data Reader</param>
        /// <param name="action">Action</param>
        /// <returns>Model</returns>
        T Model(IDataReader reader, ActionFlags action = ActionFlags.Load);
        #endregion

        #region DataTable
        /// <summary>
        /// Generate Models from Data Table
        /// </summary>
        /// <param name="data">Data Table</param>
        /// <param name="action">Action</param>
        /// <returns>Models</returns>
        IEnumerable<T> Models(DataTable data, ActionFlags action = ActionFlags.Load);

        /// <summary>
        /// Generate Model from Data Table
        /// </summary>
        /// <param name="data">Data Table</param>
        /// <param name="action">Action</param>
        /// <returns>Model</returns>
        T Model(DataTable data, ActionFlags action = ActionFlags.Load);
        #endregion

        #region DataSet
        IEnumerable<T> Models(DataSet data, ActionFlags action = ActionFlags.Load);
        T Model(DataSet data, ActionFlags action = ActionFlags.Load);
        #endregion
    }
    #endregion

    #region ILoader
    /// <summary>
    /// Loader interface to enable mocking frameworks for unit testing
    /// </summary>
    public interface IDynamicLoader
    {
        #region IDbCommand
        #endregion

        #region IDataReader
        #endregion

        #region DataTable
        IDictionary<string, object> Dictionary(DataTable data);
        IEnumerable<IDictionary<string, object>> Dictionaries(DataTable data);
        #endregion

        #region DataSet
        #endregion
    }
    #endregion

    #region IExecutor
    /// <summary>
    /// Execution Interface
    /// </summary>
    public interface IExecutor
    {
        #region Methods
        /// <summary>
        /// Execute Sproc for mocking
        /// </summary>
        /// <param name="sproc"></param>
        /// <returns></returns>
        Task<DataSet> Query(IStoredProcedure sproc);

        /// <summary>
        /// Non Query sproc for mocking
        /// </summary>
        /// <param name="sproc"></param>
        /// <returns></returns>
        Task<int> NonQuery(IStoredProcedure sproc);

        /// <summary>
        /// Query for Reader with IStoredProcecure
        /// </summary>
        /// <param name="sproc">Stored Procedure</param>
        /// <returns>Data Reader</returns>
        Task<IDataReader> DataReader(IStoredProcedure sproc);
        #endregion
    }
    #endregion

    #region IStoredProcedure
    /// <summary>
    /// Stored Procedure
    /// </summary>
    public interface IStoredProcedure
    {
        #region Methods
        /// <summary>
        /// Fully Qualified Stored Procedure Name
        /// </summary>
        string FullyQualifiedName();
        #endregion
    }
    #endregion
}