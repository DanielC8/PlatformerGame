# Platformer

A 2D side-scrolling platformer built in Unity. Jump through three levels, collect items, defeat enemies, and reach the flag before time runs out. Built during CMU's National High School Game Academy (NHSGA) in the summer of 2025.

## Features

- **3 Playable Levels:** Progressive difficulty with unique tilemap layouts, enemy placements, and collectible arrangements.
- **Lives & Respawn System:** Start with 3 lives. Taking damage or running out of time costs a life and resets you to a respawn point. Lose all lives and it's game over.
- **Score System:** Earn points from collecting coins, cherries, and defeating enemies. Bananas grant a 2x score multiplier for 5 seconds.
- **Enemy Types:**
  - *Slimes* — Patrol back and forth between turn-around points. Jump on them to kill.
  - *Dragons* — Stationary enemies that shoot fireballs every 2 seconds. Jump on them to kill.
- **Moving Platforms:** Horizontal platforms the player can ride.
- **Timer:** Each level has a countdown timer. Running out of time costs a life and respawns the player.
- **Level Progression:** Completing a level automatically advances to the next. Beat all 3 to win.

## Project Structure

```
Assets/
├── Animations/            # Animator controllers and animation clips
├── Audio/                 # SFX (jump, coin, death, etc.) and music tracks
├── Pixel Adventure 1/     # Sprite asset pack (characters, items, terrain)
├── Prefabs/               # Reusable game objects (see below)
├── Scenes/                # 5 scenes (StartScene, LevelSelectScene, GameLevel1-3, EndScene)
├── Scripts/               # 14 C# scripts (see below)
├── Sprites/               # Additional sprite assets
├── TileMap/               # Tileset assets and terrain prefab
├── TextMesh Pro/          # UI text rendering assets
└── Thaleah_PixelFont/     # Pixel font for UI
```

### Prefabs

| Prefab | Description |
|---|---|
| `Enemy-P` | Slime enemy with patrol AI |
| `Enemy-Dragon` | Dragon enemy that shoots fireballs |
| `Fireball` | Dragon projectile, moves left and self-destructs after 4 seconds |
| `Coin-P` | Coin collectible |
| `Cherry-P` | Cherry collectible |
| `Banana-P` | Banana power-up (2x score multiplier) |
| `Flag` | End-of-level goal |
| `TurnAroundObject` | Invisible boundary that reverses enemy patrol direction |
| `MovingPlatformParent` | Moving platform the player can ride |

### Scripts

| Script | Class | Description |
|---|---|---|
| `GameManager.cs` | `GameManager` | Singleton. Manages game state (menu, playing, win, lose), score, lives, timer, level progression, and score multiplier. |
| `PlayerCharacterController.cs` | `PlayerCharacterController` | Handles player movement (arrow keys / WASD), jumping (space/W/up), ground detection, sprite flipping, and collision with enemies/flags. |
| `SlimeController.cs` | `EnemyController` | Slime patrol AI. Moves horizontally, reverses direction at turn-around triggers, dies on player contact from above. |
| `DragonController.cs` | `DragonController` | Dragon enemy. Spawns fireballs every 2 seconds. Dies on player contact from above. |
| `FireballScript.cs` | `FireballScript` | Projectile behavior. Moves left at constant velocity, auto-destroys after 4 seconds. |
| `ItemController.cs` | `CoinController` | Handles coin, cherry, and banana collection. Awards score, plays per-item SFX, triggers banana's 2x multiplier. |
| `KillPlayer.cs` | `KillPlayer` | Attached to hazard zones. Kills the player on contact. |
| `PlatformHorizontal.cs` | `PlatformHorizontal` | Parents the player to the platform on contact so they move together. |
| `CameraScript.cs` | `CameraScript` | Follows the player horizontally using SmoothDamp. Y-position stays fixed relative to the respawn point. |
| `UIManager.cs` | `UIManager` | Displays remaining lives as knight sprite icons in the HUD. |
| `WinLoseUI.cs` | `WinLoseUI` | Shows win/lose panel and message text at end of game. |
| `EndUIManager.cs` | `EndUIManager` | Displays the final score on the end screen. |
| `SoundManager.cs` | `SoundManager` | Singleton. Manages all SFX (jump, coin, cherry, banana, kill, death, button, win) and switches between menu and gameplay music. |
| `ButtonController.cs` | `ButtonController` | Handles level select buttons, exit button, scene loading, and game state resets. |

## How It Works

1. **Start Menu** — Player launches the game and sees the start screen.
2. **Level Select** — Player picks Level 1, 2, or 3.
3. **Gameplay** — Player runs, jumps, collects items, avoids/kills enemies, and reaches the flag before time runs out.
4. **Level Progression** — Reaching the flag advances to the next level. After Level 3, the player wins.
5. **Game Over** — Losing all 3 lives ends the game. The end screen shows the final score.

## Controls

| Key | Action |
|---|---|
| Arrow Keys / A, D | Move left/right |
| Space / W / Up Arrow | Jump |
| ESC | Quit |

## Requirements

- Unity (2D project)
- TextMesh Pro (included in Unity)

## How to Run

1. Clone the repository.
2. Open the project in Unity.
3. Open `Assets/Scenes/StartScene` and press Play.
