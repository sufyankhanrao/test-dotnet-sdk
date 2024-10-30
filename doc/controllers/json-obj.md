# Json Obj

```csharp
IJsonObjController jsonObjController = client.JsonObjController;
```

## Class Name

`JsonObjController`

## Methods

* [Send Schemain Model](../../doc/controllers/json-obj.md#send-schemain-model)
* [Send Schemaas Body](../../doc/controllers/json-obj.md#send-schemaas-body)
* [Send Schemaas Form](../../doc/controllers/json-obj.md#send-schemaas-form)
* [Send Schemaas Query](../../doc/controllers/json-obj.md#send-schemaas-query)
* [Get Schema](../../doc/controllers/json-obj.md#get-schema)
* [Get Schema Array](../../doc/controllers/json-obj.md#get-schema-array)
* [Get Schema Map](../../doc/controllers/json-obj.md#get-schema-map)
* [Get Schemain Model](../../doc/controllers/json-obj.md#get-schemain-model)


# Send Schemain Model

Send Schema in Model

```csharp
SendSchemainModelAsync(
    Models.SchemaContainer body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`SchemaContainer`](../../doc/models/schema-container.md) | Body, Required | - |

## Response Type

[`Task<Models.ServerResponse>`](../../doc/models/server-response.md)

## Example Usage

```csharp
SchemaContainer body = new SchemaContainer
{
    Name = "a name",
    Id = "definition-123",
    Schema = JsonObject.FromJsonString("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};

try
{
    ServerResponse result = await jsonObjController.SendSchemainModelAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Send Schemaas Body

Send Schema as Body

```csharp
SendSchemaasBodyAsync(
    JsonObject body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | `JsonObject` | Body, Required | - |

## Response Type

[`Task<Models.ServerResponse>`](../../doc/models/server-response.md)

## Example Usage

```csharp
JsonObject body = JsonObject.FromJsonString("{\"key1\":\"val1\",\"key2\":\"val2\"}");
try
{
    ServerResponse result = await jsonObjController.SendSchemaasBodyAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Send Schemaas Form

Send Schema as Form

```csharp
SendSchemaasFormAsync(
    Models.SendSchemaasFormInput input)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `contentType` | [`ContentType`](../../doc/models/content-type.md) | Header, Required | - |
| `id` | `int` | Form, Required | - |
| `model` | `JsonObject` | Form, Required | - |
| `modelArray` | `List<JsonObject>` | Form, Optional | - |
| `modelMap` | `JsonObject` | Form, Optional | - |

## Response Type

[`Task<Models.ServerResponse>`](../../doc/models/server-response.md)

## Example Usage

```csharp
SendSchemaasFormInput sendSchemaasFormInput = new SendSchemaasFormInput
{
    ContentType = ContentType.EnumApplicationxwwwformurlencoded,
    Id = 112,
    Model = JsonObject.FromJsonString("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};

try
{
    ServerResponse result = await jsonObjController.SendSchemaasFormAsync(sendSchemaasFormInput);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Send Schemaas Query

Send Schema as Query

```csharp
SendSchemaasQueryAsync(
    Models.SendSchemaasQueryInput input)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `int` | Query, Required | - |
| `model` | `JsonObject` | Query, Required | - |
| `modelArray` | `List<JsonObject>` | Query, Optional | - |
| `modelMap` | `JsonObject` | Query, Optional | - |

## Response Type

[`Task<Models.ServerResponse>`](../../doc/models/server-response.md)

## Example Usage

```csharp
SendSchemaasQueryInput sendSchemaasQueryInput = new SendSchemaasQueryInput
{
    Id = 112,
    Model = JsonObject.FromJsonString("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};

try
{
    ServerResponse result = await jsonObjController.SendSchemaasQueryAsync(sendSchemaasQueryInput);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Get Schema

Get Schema

```csharp
GetSchemaAsync()
```

## Response Type

`Task<JsonObject>`

## Example Usage

```csharp
try
{
    JsonObject result = await jsonObjController.GetSchemaAsync();
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Get Schema Array

Get Schema Array

```csharp
GetSchemaArrayAsync()
```

## Response Type

`Task<List<JsonObject>>`

## Example Usage

```csharp
try
{
    List<JsonObject> result = await jsonObjController.GetSchemaArrayAsync();
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Get Schema Map

Get Schema Map

```csharp
GetSchemaMapAsync()
```

## Response Type

`Task<JsonObject>`

## Example Usage

```csharp
try
{
    JsonObject result = await jsonObjController.GetSchemaMapAsync();
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Get Schemain Model

Get Schema in Model

```csharp
GetSchemainModelAsync()
```

## Response Type

[`Task<Models.SchemaContainer>`](../../doc/models/schema-container.md)

## Example Usage

```csharp
try
{
    SchemaContainer result = await jsonObjController.GetSchemainModelAsync();
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

