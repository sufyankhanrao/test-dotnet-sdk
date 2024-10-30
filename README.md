
# Getting Started with Json Value Tester

## Introduction

Testing Special JsonValue feature

## Building

The generated code uses the Newtonsoft Json.NET NuGet Package. If the automatic NuGet package restore is enabled, these dependencies will be installed automatically. Therefore, you will need internet access for build.

* Open the solution (JsonValueTester.sln) file.

Invoke the build process using Ctrl + Shift + B shortcut key or using the Build menu as shown below.

The build process generates a portable class library, which can be used like a normal class library. More information on how to use can be found at the MSDN Portable Class Libraries documentation.

The supported version is **.NET Standard 2.0**. For checking compatibility of your .NET implementation with the generated library, [click here](https://dotnet.microsoft.com/en-us/platform/dotnet-standard#versions).

## Installation

The following section explains how to use the JsonValueTester.Standard library in a new project.

### 1. Starting a new project

For starting a new project, right click on the current solution from the solution explorer and choose `Add -> New Project`.

![Add a new project in Visual Studio](https://apidocs.io/illustration/cs?workspaceFolder=Json%20Value%20Tester-CSharp&workspaceName=JsonValueTester&projectName=JsonValueTester.Standard&rootNamespace=JsonValueTester.Standard&step=addProject)

Next, choose `Console Application`, provide `TestConsoleProject` as the project name and click OK.

![Create a new Console Application in Visual Studio](https://apidocs.io/illustration/cs?workspaceFolder=Json%20Value%20Tester-CSharp&workspaceName=JsonValueTester&projectName=JsonValueTester.Standard&rootNamespace=JsonValueTester.Standard&step=createProject)

### 2. Set as startup project

The new console project is the entry point for the eventual execution. This requires us to set the `TestConsoleProject` as the start-up project. To do this, right-click on the `TestConsoleProject` and choose `Set as StartUp Project` form the context menu.

![Adding a project reference](https://apidocs.io/illustration/cs?workspaceFolder=Json%20Value%20Tester-CSharp&workspaceName=JsonValueTester&projectName=JsonValueTester.Standard&rootNamespace=JsonValueTester.Standard&step=setStartup)

### 3. Add reference of the library project

In order to use the `JsonValueTester.Standard` library in the new project, first we must add a project reference to the `TestConsoleProject`. First, right click on the `References` node in the solution explorer and click `Add Reference...`

![Adding a project reference](https://apidocs.io/illustration/cs?workspaceFolder=Json%20Value%20Tester-CSharp&workspaceName=JsonValueTester&projectName=JsonValueTester.Standard&rootNamespace=JsonValueTester.Standard&step=addReference)

Next, a window will be displayed where we must set the `checkbox` on `JsonValueTester.Standard` and click `OK`. By doing this, we have added a reference of the `JsonValueTester.Standard` project into the new `TestConsoleProject`.

![Creating a project reference](https://apidocs.io/illustration/cs?workspaceFolder=Json%20Value%20Tester-CSharp&workspaceName=JsonValueTester&projectName=JsonValueTester.Standard&rootNamespace=JsonValueTester.Standard&step=createReference)

### 4. Write sample code

Once the `TestConsoleProject` is created, a file named `Program.cs` will be visible in the solution explorer with an empty `Main` method. This is the entry point for the execution of the entire solution. Here, you can add code to initialize the client library and acquire the instance of a Controller class. Sample code to initialize the client library and using Controller methods is given in the subsequent sections.

![Adding a project reference](https://apidocs.io/illustration/cs?workspaceFolder=Json%20Value%20Tester-CSharp&workspaceName=JsonValueTester&projectName=JsonValueTester.Standard&rootNamespace=JsonValueTester.Standard&step=addCode)

## Test the SDK

The generated SDK also contain one or more Tests, which are contained in the Tests project. In order to invoke these test cases, you will need `NUnit 3.0 Test Adapter Extension` for Visual Studio. Once the SDK is complied, the test cases should appear in the Test Explorer window. Here, you can click `Run All` to execute these test cases.

## Initialize the API Client

**_Note:_** Documentation for the client can be found [here.](https://www.github.com/sufyankhanrao/test-dotnet-sdk/tree/1.1.2/doc/client.md)

The following parameters are configurable for the API Client:

| Parameter | Type | Description |
|  --- | --- | --- |
| `Environment` | `Environment` | The API environment. <br> **Default: `Environment.Testing`** |
| `Timeout` | `TimeSpan` | Http client timeout.<br>*Default*: `TimeSpan.FromSeconds(100)` |

The API client can be initialized as follows:

```csharp
JsonValueTesterClient client = new JsonValueTesterClient.Builder()
    .Environment(JsonValueTester.Standard.Environment.Testing)
    .Build();
```

## Environments

The SDK can be configured to use a different environment for making API calls. Available environments are:

### Fields

| Name | Description |
|  --- | --- |
| production | - |
| testing | **Default** |

## List of APIs

* [Json Obj](https://www.github.com/sufyankhanrao/test-dotnet-sdk/tree/1.1.2/doc/controllers/json-obj.md)
* [Json Val](https://www.github.com/sufyankhanrao/test-dotnet-sdk/tree/1.1.2/doc/controllers/json-val.md)

## Classes Documentation

* [Utility Classes](https://www.github.com/sufyankhanrao/test-dotnet-sdk/tree/1.1.2/doc/utility-classes.md)
* [HttpRequest](https://www.github.com/sufyankhanrao/test-dotnet-sdk/tree/1.1.2/doc/http-request.md)
* [HttpResponse](https://www.github.com/sufyankhanrao/test-dotnet-sdk/tree/1.1.2/doc/http-response.md)
* [HttpStringResponse](https://www.github.com/sufyankhanrao/test-dotnet-sdk/tree/1.1.2/doc/http-string-response.md)
* [HttpContext](https://www.github.com/sufyankhanrao/test-dotnet-sdk/tree/1.1.2/doc/http-context.md)
* [HttpClientConfiguration](https://www.github.com/sufyankhanrao/test-dotnet-sdk/tree/1.1.2/doc/http-client-configuration.md)
* [HttpClientConfiguration Builder](https://www.github.com/sufyankhanrao/test-dotnet-sdk/tree/1.1.2/doc/http-client-configuration-builder.md)
* [IAuthManager](https://www.github.com/sufyankhanrao/test-dotnet-sdk/tree/1.1.2/doc/i-auth-manager.md)
* [ApiException](https://www.github.com/sufyankhanrao/test-dotnet-sdk/tree/1.1.2/doc/api-exception.md)

