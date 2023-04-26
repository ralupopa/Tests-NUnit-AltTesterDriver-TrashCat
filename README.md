## Prerequisite

1. Download and install [.NET SDK](https://dotnet.microsoft.com/en-us/download)
2. Have a game [instrumented with AltTester Unity SDK](https://alttester.com/docs/sdk/pages/get-started.html#instrument-your-game-with-alttester-unity-sdk)
3. Have [AltTester Desktop app](https://alttester.com/alttester/) installed (to be able to inspect game)

# Tests created with NUnit & AltTester-Driver for a game developed w/ Unity (TrashCat)

This repository is a test project that uses NUnit as the test library. It was generated using following command (as suggested in [documentation](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit#creating-the-test-project))

```
dotnet new nunit
```

[AltTester Unity SDK framework](https://alttester.com/docs/sdk/) contains `AltDriver` class used to connect to the instrumented game developed w/ Unity. AltTester-Driver for C# is available as a nuget package. Install [AltTester-Driver nuget package](https://www.nuget.org/packages/AltTester-Driver#versions-body-tab)

```
dotnet add package AltTester-Driver --version 1.8.2
```

# Run tests manually (with [dotnet CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-test))

1. Launch game
2. From `TrashCat.Tests` execute all tests:

```
dotnet test
```

! **Make sure to have the AltTester Desktop App closed, otherwise the test won't be able to connect to proper port.**

### Run all tests from a specific class / file

```
dotnet test --filter <test_class_name>
```

### Run only one test from a class

```
dotnet test --filter <test_class_name>.<test_name>
```

# Used the following AltObject methods which interact with components (methods, fields, properties)

- [x] [CallComponentMethod](https://alttester.com/docs/sdk/pages/commands.html#callcomponentmethod)
- [x] [GetComponentProperty](https://alttester.com/docs/sdk/pages/commands.html#getcomponentproperty)
- [x] [SetComponentProperty](https://alttester.com/docs/sdk/pages/commands.html#setcomponentproperty)
- [x] [GetText](https://alttester.com/docs/sdk/pages/commands.html#gettext)
- [x] [SetText](https://alttester.com/docs/sdk/pages/commands.html#settext)
- [x] [GetParent](https://alttester.com/docs/sdk/pages/commands.html#getparent)
- [x] [UpdateObject](https://alttester.com/docs/sdk/pages/commands.html#updateobject)
- [x] [Tap](https://alttester.com/docs/sdk/pages/commands.html#id1)
- [x] [Click](https://alttester.com/docs/sdk/pages/commands.html#id2)
- [x] [PointerDownFromObject](https://alttester.com/docs/sdk/pages/commands.html#pointerdown)
- [x] [PointerUpFromObject](https://alttester.com/docs/sdk/pages/commands.html#pointerup)
- [ ] [PointerEnterObject](https://alttester.com/docs/sdk/pages/commands.html#pointerenter)
- [ ] [PointerExitObject](https://alttester.com/docs/sdk/pages/commands.html#pointerexit)
- [x] GetWorldPosition
- [x] GetScreenPosition
- [ ] ~~WaitForComponentProperty~~ it's not implemented for 1.8.2, will be available in future
- [x] GetAllComponents
- [x] GetAllProperties
- [ ] GetAllMethods

# Used the following AltDriver > Unity Commands methods
- [ ] [CallStaticMethod](https://alttester.com/docs/sdk/pages/commands.html#callstaticmethod) 


### Workaround for being able to use SDK 1.8.2 installed as package in project:
- get `altwebsocket-sharp.dll` from [here](https://github.com/alttester/AltTester-Unity-SDK/tree/development/Assets/AltTester/3rdParty/websocket-sharp/netstandard2.0) and put in project's bin\Debug\net7.0

this was necessary due to currently open [issue](https://github.com/alttester/AltTester-Unity-SDK/issues/1192) 