﻿using System;
using System.IO;
using MalongTech.ProductAI.Core;

namespace MalongTech.ProductAI.API
{
    [IgnoreExtraParas]
    public abstract class DataSetBatchModifyByFileBaseRequest<T> : BaseRequest<T>
        where T : BaseResponse
    {
        private string _imageSetId = "";
        private string _opType = "urls_to_add";

        public override string ApiUrl
        {
            get
            {
                return string.Format("https://{0}/image_sets/_0000014/{1}", this.Host, this._imageSetId);
            }
        }

        public override string QueryString
        {
            get
            {
                return "";
            }
        }

        private string _boundary = "";

        public override byte[] QueryBytes
        {
            get
            {
                return FileHelper.GetMultipartBytes(this.CsvFile, _boundary, null, _opType);
            }
        }

        public override string ContentTypeHeader
        {
            get
            {
                return FileHelper.GetContentType(_boundary);
            }
        }

        public FileInfo CsvFile { get; set; }

        public DataSetBatchModifyByFileBaseRequest(string imageSetId, string opType = "urls_to_add")
        : base()
        {
            if (string.IsNullOrWhiteSpace(imageSetId))
                throw new ArgumentNullException(nameof(imageSetId));

            this._imageSetId = imageSetId;
            this._opType = opType;

            this._boundary = FileHelper.GetBoundary();
        }

        public DataSetBatchModifyByFileBaseRequest(string imageSetId, FileInfo csvFile, string opType = "urls_to_add")
                : this(imageSetId, opType)
        {
            this.CsvFile = csvFile;
        }
    }
}