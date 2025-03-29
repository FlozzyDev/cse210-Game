# Tutorial
## Topic
Null-Forgiving Operator 

## Author
Dallin Hale

## Overview
This operator is used to suppress the compiler errors that can happen when a reference object is not immediately instantiated. In this case, I was unable to immediately create my player class because I needed ray.lib to load first so I could load the player texture. But when I waited to load the player in the initialization phase of the game, I got an error since it was null at compile time. This operator allows me to "promise" that by the time the object is going to be used in runtime, it will be available. 

## Purpose
The purpose is to allow developers to have a bit more control and flexibility when creating something. There are times when a non-nullable field can't be created in the constructor (like my pirate game) and this allows me to move on. 

## Syntax
It's a simple syntax, just adding a (!) after the null portion when first defining the object

```
private Player _player = null!; 
```

And then in this case, as soon as the game starts and initialization is called, we create a player we can use. 

## Discussion
I'm sure there is probably a better way at doing this, but at this point I got so far that I didn't want to change how I was initializing the game or when I was loading the texture. I understand this isn't something you want to use very often as it starts to defeat the whole purpose of having nullable reference types. If I was going to continue on with this project, I would refactor my code and find a better process for creating game objects. 

## Sources (some info on null exceptions in general as well since I wasn't aware)
https://learn.microsoft.com/en-us/dotnet/api/system.nullreferenceexception?view=net-9.0
https://stackoverflow.com/questions/4660142/what-is-a-nullreferenceexception-and-how-do-i-fix-it
https://www.youtube.com/watch?v=UzSdzOK4UN8

