# Shooter Game 
Two player, controller by one keyboard, fight to death.

## Controls 

### Player 1
| Key | Function |
|----------|----|
| W | Walk Up |
| A | Walk Left |
| S | Walk Down |
| D | Walk Right |
| G | Rotate Left |
| H | Rotate Right |
| Space | Shoot |

### Player 2
| Key | Function |
|----------|----|
| Up key | Walk Up |
| Left key | Walk Left |
| Down Key | Walk Down |
| Right Key | Walk Right |
| Numpad 4 | Rotate Left |
| Numpad 5 | Rotate Right |
| Numpad 0 | Shoot |

## Technical summary
There are 4 distinc object in the game:
- Players - Include a gun
- Walls 
- Spawn points - are invisible but can be placed freely using the editor
- Bullets

Every game object has its own collision, the only change i had to do is make bullets not intersect with thier owner.
[Code link](https://github.com/Daniel-WORK-GH/ShooterGame/blob/0abcfe988226b79460380443d4badc1b3e032509/Assets/Scripts/Bullet.cs#L24C5-L24C51)

Players can have their own uniqe controls that can be set in the editor.
[Code link](https://github.com/Daniel-WORK-GH/ShooterGame/blob/0abcfe988226b79460380443d4badc1b3e032509/Assets/Scripts/Player.cs#L12)

## Game Loop
The game loop is pretty simple - two players fight each other until one of them dies, they then reswpawn at random positions and rotations and can fight again.
