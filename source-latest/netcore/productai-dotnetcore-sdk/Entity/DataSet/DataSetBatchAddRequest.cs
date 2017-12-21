using System;

namespace MalongTech.ProductAI.API.Entity
{
    /// <summary>
    /// 向数据集增加多条数据
    /// <para>https://api-doc.productai.cn/doc/pai.html#向数据集增加多条数据</para>
    /// </summary>
    public class DataSetBatchAddRequest
        : DataSetBatchModifyByFileBaseRequest<DataSetBaseResponse>
    {
        public DataSetBatchAddRequest(string imageSetId)
            : base(imageSetId, "urls_to_add")
        {

        }

        public DataSetBatchAddRequest(string imageSetId, System.IO.FileInfo csvFile)
            : this(imageSetId)
        {
            this.CsvFile = csvFile;
        }
    }
}