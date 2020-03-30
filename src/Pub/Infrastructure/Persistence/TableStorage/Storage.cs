using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Infrastructure.Persistence.TableStorage
{
    public class Storage<T> where T : TableEntity
    {
        private readonly CloudTable _storageTable;
        public Storage(string tableStorageConnectionString, string storageTableName)
        {
            CloudStorageAccount _account = CloudStorageAccount.Parse(tableStorageConnectionString);
            CloudTableClient _tableStorageClient = _account.CreateCloudTableClient();
            _storageTable = _tableStorageClient.GetTableReference(storageTableName);
            _storageTable.CreateIfNotExistsAsync().Wait();
        }

        public async Task<T> RetrieveEntity(string partitionKey, string rowKey)
        {
            TableOperation operation = TableOperation.Retrieve<T>(partitionKey, rowKey);
            TableResult result = await _storageTable.ExecuteAsync(operation);
            var entity = result.Result as T;
            return entity;
        }

        public async Task<T> InsertOrMerge(T tableEntity)
        {
            TableOperation operation = TableOperation.InsertOrMerge(tableEntity);
            TableResult result = await _storageTable.ExecuteAsync(operation);
            var entity = result.Result as T;
            return entity;
        }
    }
}