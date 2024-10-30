# Json Val

```csharp
IJsonValController jsonValController = client.JsonValController;
```

## Class Name

`JsonValController`

## Methods

* [Send Valuein Model](../../doc/controllers/json-val.md#send-valuein-model)
* [Send Valueas Body](../../doc/controllers/json-val.md#send-valueas-body)
* [Send Valueas Form](../../doc/controllers/json-val.md#send-valueas-form)
* [Send Valueas Query](../../doc/controllers/json-val.md#send-valueas-query)
* [Get Value](../../doc/controllers/json-val.md#get-value)
* [Get Value Array](../../doc/controllers/json-val.md#get-value-array)
* [Get Value Map](../../doc/controllers/json-val.md#get-value-map)
* [Get Valuein Model](../../doc/controllers/json-val.md#get-valuein-model)


# Send Valuein Model

Send Value in Model

```csharp
SendValueinModelAsync(
    Models.ValueContainer body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`ValueContainer`](../../doc/models/value-container.md) | Body, Required | - |

## Response Type

[`Task<Models.ServerResponse>`](../../doc/models/server-response.md)

## Example Usage

```csharp
ValueContainer body = new ValueContainer
{
    Name = "a name",
    Id = "definition-123",
    MValue = JsonValue.FromObject("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};

try
{
    ServerResponse result = await jsonValController.SendValueinModelAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Send Valueas Body

Send Value as Body

```csharp
SendValueasBodyAsync(
    JsonValue body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | `JsonValue` | Body, Required | - |

## Response Type

[`Task<Models.ServerResponse>`](../../doc/models/server-response.md)

## Example Usage

```csharp
JsonValue body = JsonValue.FromObject("{\"key1\":\"val1\",\"key2\":\"val2\"}");
try
{
    ServerResponse result = await jsonValController.SendValueasBodyAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Send Valueas Form

Send Value as Form

```csharp
SendValueasFormAsync(
    Models.SendValueasFormInput input)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `contentType` | [`ContentType`](../../doc/models/content-type.md) | Header, Required | - |
| `id` | `int` | Form, Required | - |
| `model` | `JsonValue` | Form, Required | - |
| `modelArray` | `List<JsonValue>` | Form, Optional | - |
| `modelMap` | `JsonValue` | Form, Optional | - |

## Response Type

[`Task<Models.ServerResponse>`](../../doc/models/server-response.md)

## Example Usage

```csharp
SendValueasFormInput sendValueasFormInput = new SendValueasFormInput
{
    ContentType = ContentType.EnumApplicationxwwwformurlencoded,
    Id = 112,
    Model = JsonValue.FromObject("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};

try
{
    ServerResponse result = await jsonValController.SendValueasFormAsync(sendValueasFormInput);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Send Valueas Query

Send Value as Query

```csharp
SendValueasQueryAsync(
    Models.SendValueasQueryInput input)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `int` | Query, Required | - |
| `model` | `JsonValue` | Query, Required | - |
| `modelArray` | `List<JsonValue>` | Query, Optional | - |
| `modelMap` | `JsonValue` | Query, Optional | - |

## Response Type

[`Task<Models.ServerResponse>`](../../doc/models/server-response.md)

## Example Usage

```csharp
SendValueasQueryInput sendValueasQueryInput = new SendValueasQueryInput
{
    Id = 112,
    Model = JsonValue.FromObject("{\"key1\":\"val1\",\"key2\":\"val2\"}"),
};

try
{
    ServerResponse result = await jsonValController.SendValueasQueryAsync(sendValueasQueryInput);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Get Value

Get Value

```csharp
GetValueAsync()
```

## Response Type

`Task<JsonValue>`

## Example Usage

```csharp
try
{
    JsonValue result = await jsonValController.GetValueAsync();
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Get Value Array

Get Value Array

```csharp
GetValueArrayAsync()
```

## Response Type

`Task<List<JsonValue>>`

## Example Usage

```csharp
try
{
    List<JsonValue> result = await jsonValController.GetValueArrayAsync();
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Get Value Map

Get Value Map

```csharp
GetValueMapAsync()
```

## Response Type

`Task<JsonValue>`

## Example Usage

```csharp
try
{
    JsonValue result = await jsonValController.GetValueMapAsync();
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Get Valuein Model

Get Value in Model

```csharp
GetValueinModelAsync()
```

## Response Type

[`Task<Models.ValueContainer>`](../../doc/models/value-container.md)

## Example Usage

```csharp
try
{
    ValueContainer result = await jsonValController.GetValueinModelAsync();
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

