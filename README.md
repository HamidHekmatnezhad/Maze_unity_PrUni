# 🎮 3D Maze Runner Game (v0.1.0 - Core Mechanics)

This is a simple 3D Maze Runner project, developed using the **Unity** engine and **C#** scripting. This initial version focuses on implementing the core mechanics of player movement, collision handling for scoring items (Collectibles), and enemy interaction, featuring dynamic respawning.

## ✨ Core Features (v0.1.0)

* **Physics-Based Movement:** Player movement utilizes `Rigidbody` and `AddForce` for smooth, physics-driven control, including jumping with the **Spacebar**.
* **Dynamic Respawn Logic:** Both the Collectible and the Enemy will instantly **despawn and respawn** at a new random location upon collision with the player, ensuring constant movement within the maze.
* **Simple Scoring:** Points are tracked and logged to the console (`Debug.Log`).

---

## 🕹️ How to Play

* **Movement Control:** Use the **W**, **A**, **S**, **D** keys or the arrow keys.
* **Jumping:** Press the **Spacebar**.

### 🎯 Collision Mechanics

The game uses a dynamic interaction system where one object's destruction triggers the relocation of the other.

| Object Hit | Score Change | Collision Effect |
| :--- | :--- | :--- |
| **Collectible (Cube)** | **+1 Point** | The Collectible is destroyed, and the **current Enemy is destroyed**. A new Collectible and a new Enemy are immediately spawned at random locations. |
| **Enemy** | **-1 Point** | The Enemy is destroyed, and the **current Collectible is destroyed**. A new Enemy and a new Collectible are immediately spawned at random locations. |

---

## 📁 Project Structure

The key components and files in this project:

| Path | Description |
| :--- | :--- |
| **Assets/Script/Move.cs** | The main game script containing all logic for player movement, collision detection, scoring, and dynamic object respawning. |
| **Assets/Prefab** | Contains the Prefabs for the collectible item (`Cube.prefab`) and the enemy (`enemy.prefab`). |
| **Assets/Scenes** | Contains the main game scene (`SampleScene.unity`). |

---

## ⚙️ Technical Details (`Move.cs` Script)

The core logic resides in the `Move` class, which is attached to the player object.

### Key Variables

| Variable | Type | Role |
| :--- | :--- | :--- |
| `speed` | `float` | Controls the force applied for movement (set to 2.0f). |
| `points` | `int` | Stores the player's current score. |
| `prefab` | `GameObject` | **Prefab reference** for the Collectible item. |
| `enemy` | `GameObject` | **Prefab reference** for the Enemy. |
| `currentPrefab` | `GameObject` | **Instance reference** to the currently spawned Collectible in the scene. |
| `currentEnemy` | `GameObject` | **Instance reference** to the currently spawned Enemy in the scene. |

### Respawn Logic (`respown_obj` function)

The `respown_obj` function handles the creation of new instances at random positions within the defined maze boundaries:

* **X Boundaries:** `[-38.0f, 2.0f]`
* **Z Boundaries:** `[-21.0f, 28.0f]`

### Initialization

The `Start()` function is used to instantiate the initial Collectible and Enemy instances, setting the game environment.

```csharp
if (start_game)
{
    currentPrefab = respown_obj(prefab, -3, 2);
    currentEnemy = respown_obj(enemy, -3, 0);
    start_game = false;
}