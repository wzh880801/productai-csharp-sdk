# productar-csharp-sdk

# 安装
Nuget关键字:
ProductAI,Malong
Nuget命令行
Install-Package MalongTech.ProductAI.API 

# 快速入门

## Setup your account
```csharp
	 string accessKeyId = "your access key id";                        //require: 你的用户配置access_key_id
	 string secretKey =  "your secret key";                            //require: 你的用户配置secret_key 
	 ProductAIService api =
	    new ProductAIService(
	        accessKeyId,                                                 
	        secretKey                                                    
	        );        
```

## Search image using image file path
```csharp
        string imagePath;

        Dictionary<string,string> options = new Dictionary<string, string>();
        options.Add("loc","0-0-1-1");                                           //option: 图片标框的位置信息
        options.Add("count","1");

        bool isError = true;
        string respContent = "";//option: 设置总数限制

        isError =
        api.SubmitFileToSearch(
                serviceType,                                                    //require: 你的服务类型
                serviveId,                                                      //require: 你的服务ID
                imagePath,                                                      //require: 你的本地图片本地路径
                options,
                out respContent                                                 //请求返回结果获取错误数据
                );

        if (isError) {
        System.Console.WriteLine("request failed!");
        } else {
        System.Console.WriteLine("request success!");
        }
```

## Search image async using image file path
```csharp

        string imagePath ";

        Dictionary<string,string> options = new Dictionary<string, string>();
        options.Add("loc", "0-0-1-1");                                          //option: 图片标框的位置信息
        options.Add("count", "1");                                              //option: 设置总数限制

        api.SubmitFileToSearchAsync(
        serviceType,                                                            //require: 你的服务类型
        serviveId,                                                              //require: 你的服务ID
        imagePath,                                                              //require: 你的本地图片的路径
        options,
        TestCallback                                                            //你的异步回调函数
        );
```

## Search image using image binary file
```csharp
        Dictionary<string,string> options = new Dictionary<string, string>(); 
        byte[] fileBytes;                                                       
        options.Add("loc", "0-0-1-1");                                          //option: 图片标框的位置信息
        options.Add("count", "1");                                              //option: 设置总数限制

        bool isError = true;
        string respContent = "";

        isError =
        api.SubmitFileToSearch(
                serviceType,                                                    //require: 你的服务类型
                serviveId,                                                      //require: 你的服务ID
                fileBytes,                                                      //require: 你的本地图片二进制数据
                options ,
                out respContent
                );

        if (isError) {
        System.Console.WriteLine("request failed!");
        } else {
        System.Console.WriteLine("request success!");
        }
        System.Console.WriteLine(respContent);
```

## Search image async using image binary file
```csharp
        Dictionary<string,string> options = new Dictionary<string, string>();
        byte[] fileBytes;
        options.Add("loc", "0-0-1-1");                                          //option: 图片标框的位置信息
        options.Add("count", "1");                                              //option: 设置总数限制

        api.SubmitFileToSearchAsync(
        serviceType,                                                            //require: 你的服务类型
        serviveId,                                                              //require: 你的服务ID
        fileBytes,                                                              //require: 你的本地图片二进制数据
        options,
        TestCallback
        );
```

## Search image using image url
```csharp
        string imageUrl;

        Dictionary<string,string> options = new Dictionary<string, string>();
        options.Add("loc", "0-0-1-1");                                          //option:  图片标框的位置信息

        bool isError = true;
        string respContent = "";

        isError = api.SubmitFormToSearch(
        serviceType,                                                           //require: 你的服务类型
        serviveId,                                                             //require: 你的服务ID
        imageUrl,                                                              //require: 你的图片链接
        options,
        out respContent
        );

        if (isError) {
        System.Console.WriteLine("request failed!");
        } else {
        System.Console.WriteLine("request success!");
        }
        System.Console.WriteLine(respContent);
```

## Search image async using image url
```csharp
        string imageUrl;

        Dictionary<string,string> options = new Dictionary<string, string>();
        options.Add("loc", "0-0-1-1");                                          //option:  图片标框的位置信息                                                                              

        api.SubmitFormToSearchAsync(
        serviceType,                                                            //require: 你的服务类型
        serviveId,                                                              //require: 你的服务ID
        imageUrl,                                                               //require: 你的图片链接
        options,
        TestCallback                                                            //你的异步回调函数
        );
```

## Upload images to image set using url
```csharp
        string imageUrl;

        Dictionary<string,string>  options = new Dictionary<string, string>();
        options.Add("meta","My Test");                                          //option: 附加信息

        bool isError = true;
        string respContent = "";

        isError = api.AddImageToImageSet(
        imageSetId,                                                             //require: 你的数据集ID
        imageUrl,                                                               //require: 你的图片链接
        options,
        out respContent
        );

        if (isError) {
        System.Console.WriteLine("request failed!");
        } else {
        System.Console.WriteLine("request success!");
        }
        System.Console.WriteLine(respContent);
```

## Upload images to image set async using url
```csharp
        string imageUrl;

        Dictionary<string,string>  options = new Dictionary<string, string>();
        options.Add("meta", "My Test");                                          //option: 附加信息 

        api.AddImageToImageSetAsync(
        imageSetId,                                                              //require: 你的数据集ID
        imageUrl,                                                                //require: 你的图片链接
        options,
        TestCallback                                                             //你的异步回调函数
        );
```

## Upload images to image set using a csv file
```csharp
        string csvPath;

        Dictionary<string ,string> options = new Dictionary<string, string>();

        bool isError = true;
        string respContent = "";

        isError = api.AddImageByFile(
        imageSetId,                                                              //require: 你的数据集ID
        csvPath,                                                                 //require: 你的CSV文件的路径
        options,
        out respContent
        );

        if (isError) {
        System.Console.WriteLine("request failed!");
        } else {
        System.Console.WriteLine("request success!");
        }

        System.Console.WriteLine(respContent);
```

## Upload images to image set async using a csv file
```csharp
        string csvPath;
            
        Dictionary<string ,string> options = new Dictionary<string, string>();

        api.DeleteImageByFileAsync(
        imageSetId,                                                              //require: 你的数据集ID                                                    
        csvPath,                                                                 //require: 你的CSV文件的路径
        options,
        TestCallback                                                             //你的异步回调函数
        );
```

## Remove images from image set using a csv file
```csharp
        string csvPath;

        Dictionary<string ,string> options = new Dictionary<string, string>();

        bool isError = true;
        string respContent = "";

        isError = api.DeleteImageByFile(
        imageSetId,                                                              //require: 你的数据集ID
        csvPath,                                                                 //require: 你的CSV文件的路径
        options,
        out respContent
        );

        if (isError) {
        System.Console.WriteLine("request failed!");
        } else {
        System.Console.WriteLine("request success!");
        }
        System.Console.WriteLine(respContent);
```

## Remove images from image set async using a csv file
```csharp
        string csvPath;

        Dictionary<string ,string> options = new Dictionary<string, string>();

        api.BeginDeleteImageByFile(
        imageSetId,                                                              //require: 你的数据集ID                                                    
        csvPath,                                                                 //require: 你的CSV文件的路径
        options,
        RespCallback                                                             //你的异步回调函数
        ); 
```

## request async callback function
```csharp
	    static protected void TestCallback(bool isErr, string result) {
	            if (isErr) {
	                System.Console.WriteLine("request failed!");
	            } else {
	                System.Console.WriteLine("request success!");
	            }
	            System.Console.WriteLine(result);
	  	}  
```




