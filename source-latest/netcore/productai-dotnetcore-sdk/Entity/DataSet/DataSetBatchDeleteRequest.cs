using System;

namespace MalongTech.ProductAI.API.Entity
{
    /// <summary>
    /// 从数据集删除多条数据
    /// <para>https://api-doc.productai.cn/doc/pai.html#从数据集删除多条数据</para>
    /// </summary>
    public class DataSetBatchDeleteRequest
        : DataSetBatchModifyByFileBaseRequest<DataSetBaseResponse>
    {
        public DataSetBatchDeleteRequest(string imageSetId)
            : base(imageSetId, "urls_to_delete")
        {

        }

        public DataSetBatchDeleteRequest(string imageSetId, System.IO.FileInfo csvFile)
            : this(imageSetId)
        {
            this.CsvFile = csvFile;
        }
    }
}