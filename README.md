# .NET SDK for ProductAI
.NET SDK for ProductAI

## ProductAI: 
<br>For more details about ProductAI, view [ProductAI offcial site](https://api-doc.productai.cn/doc/pai.html) [`https://api-doc.productai.cn/doc/pai.html`](https://api-doc.productai.cn/doc/pai.html)

# Usage（用法）:
```C#
using System;
using MalongTech.ProductAI.Core;
using MalongTech.ProductAI.API.Entity;

namespace MalongTech.ProductAI.Examples
{
    class Useage
    {
        void FullFlowExample()
        {
            // step 1 - setup your account profile
            // get your accessKeyId & secretKey at https://console.productai.cn/main#/21/service_category_id=1
            IProfile profile = new DefaultProfile
            {
                Version = "1",
                AccessKeyId = "XXXXXXXXXXXXXXXXXXXXX",
                SecretKey = "XXXXXXXXXXXXXXXXXXXXX",

                // set this property = null if you want to control the language type of each request
                GlobalLanguage = LanguageType.Chinese
            };

            // step 2 - initialize your ProductAI client
            var client = new DefaultProductAIClient(profile);

            // step 3 - build your request
            // take image search as example
            var request = new ImageSearchByImageUrlRequest("<your service id>")
            {
                Url = "http://productai.cn/img/f10.jpg",

                // this value will be override because you had set the IProfile.GlobalLanguage = LanguageType.Chinese
                Language = LanguageType.English
            };

            //step 4 - send out the request、receive the response、catch the exceptions
            try
            {
                var response = client.GetResponse(request);

                Console.WriteLine("==========================Result==========================");
                // access the reponse directly
                foreach (var r in response.Results)
                {
                    Console.WriteLine("{0}\t\t{1}", r.Url, r.Score);
                }
                Console.WriteLine("==========================Result==========================");
            }
            catch (ServerException ex)
            {
                Console.WriteLine("ServerException happened: \r\n\tErrorCode: {0}\r\n\tErrorMessage: {1}",
                    ex.ErrorCode,
                    ex.ErrorMessage);
            }
            catch (ClientException ex)
            {
                Console.WriteLine("ClientException happened: \r\n\tRequestId: {0}\r\n\tErrorCode:\r\n\t{1}\r\n\tErrorMessage: {2}",
                    ex.RequestId,
                    ex.ErrorCode,
                    ex.ErrorMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unknown Exception happened: {0}\r\n{1}", ex.Message, ex.StackTrace);
            }
        }
    }
}
```

# Support async (支持异步)

```C#
var request = new ImageContentAnalysisByImageUrlRequest
{
    Url = "http://dimg3.s-9in.com/imageadapter/w220h220q80/stimg4.s-9in.com/www9incom/2016/10/25/db18a2d1-bf45-439b-950f-a5b21782b62c.jpg"
};
var response = await client.ExecuteAsync(request);
```

# Examples
# 图像内物体检测与定位
## 3C电器检测与定位(detect_3c_and_electronics)
### * detect_3c_and_electronics by local image file(使用本地图片文件检测3C电器)

```C#
var request = new Detect3CElectronicsByImageFileRequest
{
    ImageFile = new System.IO.FileInfo(@".\phone.jpg")
};
var response = client.Execute(request);
foreach (var r in response.DetectedBoxes)
{
	Console.WriteLine("{0}\t{1}", r.Type, r.Score);
}
```

### * detect_3c_and_electronics by image url(使用图片Url检测3C电器)

```C#
var request = new Detect3CElectronicsByImageUrlRequest
{
    Url = "http://www.softsew.com/images/Moved%20from%20Main/More_Clothes.jpg",
    Loc = "0-0-1-1"//optional
};
var response = client.Execute(request);
```

## 交通工具检测与定位(detect_vehicle)
### * detect_vehicle by local image file(使用本地图片文件检测交通工具)

```C#
var request = new DetectVehicleByImageFileRequest
{
    ImageFile = new System.IO.FileInfo(@".\phone.jpg"),
    Loc = "0-0-1-1"//optional
};
var response = client.Execute(request);
```

### * detect_vehicle by image url(使用图片Url检测交通工具)
```C#
var request = new DetectVehicleByImageUrlRequest
{
    Url = "http://www.softsew.com/images/Moved%20from%20Main/More_Clothes.jpg",
    Loc = "0-0-1-1"//optional
};
var response = client.Execute(request);
```

## 宠物检测与定位(detect_pet)
### * detect_pet by local image file(使用本地图片文件检测宠物)

```C#
var request = new DetectPetByImageFileRequest
{
    ImageFile = new System.IO.FileInfo(@".\phone.jpg"),
    Loc = "0-0-1-1"//optional
};
var response = client.Execute(request);
```
### * detect_pet by image url(使用图片Url检测宠物)

```C#
var request = new DetectPetByImageUrlRequest
{
    Url = "http://www.softsew.com/images/Moved%20from%20Main/More_Clothes.jpg",
    Loc = "0-0-1-1"//optional
};
var response = client.Execute(request);
```

# 数据集操作
## 从数据集删除多条数据(batch delete data from image data set)

```C#
var request = new DataSetBatchDeleteRequest("bd7nvc27")//bd7nvc27 is your data set id
{
    CsvFile = new System.IO.FileInfo(@".\example.csv")
};

var response = client.Execute(request);
Console.WriteLine(response.LastModifiedTime);
```

## 向数据集增加单条数据(add single data to image data set)

```C#
var request = new DataSetSingleAddByImageUrlRequest("bd7nvc27")//bd7nvc27 is your data set id
{
    ImageUrl = "http://www.softsew.com/images/Moved%20from%20Main/More_Clothes.jpg",
    SearchTags = new List<string> { "上衣" }//set tags
};
var response = client.Execute(request);
Console.WriteLine(response.LastModifiedTime);
```

## 向数据集增加多条数据(batch add data to image data set)

```C#
var request = new DataSetBatchAddRequest("bd7nvc27")//bd7nvc27 is your data set id
{
    CsvFile = new System.IO.FileInfo(@".\example.csv")
};
var response = client.Execute(request);
Console.WriteLine(response.LastModifiedTime);
```
