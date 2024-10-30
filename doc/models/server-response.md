
# Server Response

## Structure

`ServerResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Passed` | `bool` | Required | - |
| `Message` | `string` | Optional | - |
| `Input` | `JsonObject` | Optional | - |
| `NullableNumberMap` | `Dictionary<string, double?>` | Optional | - |
| `NullableNumberArray` | `List<double?>` | Optional | - |

## Example (as JSON)

```json
{
  "passed": false,
  "Message": "Message6",
  "input": {
    "key0": {
      "key1": "val1",
      "key2": "val2"
    }
  },
  "nullableNumberMap": {
    "key0": 117.45,
    "key1": 117.46
  },
  "nullableNumberArray": [
    216.38,
    216.39,
    216.4
  ]
}
```

