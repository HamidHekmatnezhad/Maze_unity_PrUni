# 🎓 Academic Project: 3D Maze Runner Game (v0.2.0 - Dynamic Difficulty Scaling)

This project serves as a practical assignment and demonstration of core game development principles in **Unity** using **C#**. This version successfully implements dynamic difficulty scaling by linking the enemy count directly to the player's score.

**Course/Context:** [Insert Course Name or University/Semester here, e.g., Game Development Fundamentals, Fall 2025]

**Key Update from v0.1.0:** The game now supports **multiple enemies**, replacing the single enemy reference with a dynamic list (`List<GameObject> currentEnemies`) for scalable difficulty.

---

## ✨ Core Features (v0.2.0)

* **Dynamic Difficulty Scaling:** The number of enemies present on the map is always equal to the player's current `points` value (N enemies = N points).
* **Mass Respawn Mechanism:** Hitting a Collectible or an Enemy triggers the destruction and subsequent respawn of the entire current Enemy population.
* **Physics-Based Movement:** Player movement using `Rigidbody` and jumping with the **Spacebar**.

---

## 🕹️ How to Play

* **Movement Control:** Use the **W**, **A**, **S**, **D** keys.
* **Jumping:** Press the **Spacebar**.

### 🎯 Collision Mechanics

| Object Hit | Score Change | Collision Effect |
| :--- | :--- | :--- |
| **Collectible (Cube)** | **+1 Point** | Destroys the Collectible. **Destroys ALL current Enemies.** Spawns a new Collectible. Spawns a new group of **N+1** Enemies. |
| **Enemy** | **-1 Point** | Destroys the collided Enemy. **Destroys ALL current Enemies.** Spawns a new Collectible. Spawns a new group of **N-1** Enemies. |

---

## ⚙️ Technical Implementation (`Move.cs`)

The core scaling and object management logic resides in the `Move` script.

### Key Implementation Details

| Component | Status | Description |
| :--- | :--- | :--- |
| `currentEnemies` | `List<GameObject>` | Stores the instance references of all active enemies in the scene, enabling iteration and mass destruction. |
| `DestroyAllEnemies()` | `void` | Utility function that safely destroys every instance within the `currentEnemies` list and clears the list for repopulation. |
| `SpawnEnemiesByPoints()` | `void` | Utility function that iterates `points` times, calling `respown_obj` to instantiate a new Enemy for each point and saving the reference to the list. |
| **Collision Logic** | Implemented | The `OnCollisionEnter` function now calls `DestroyAllEnemies()` followed by `SpawnEnemiesByPoints()` to enforce the difficulty scaling after every interaction. |

### Respawn Boundaries

The `respown_obj` function utilizes `Random.Range` within the maze's defined coordinates:

* **X Boundaries:** `[-38.0f, 2.0f]`
* **Z Boundaries:** `[-21.0f, 28.0f]`

---

## 🚀 Future Development / Next Steps

* [ ] Implement **Game Over** state management (e.g., when points drop below zero).
* [ ] Integrate a **User Interface (UI)** to provide clear feedback on the current score and Enemy count.
* [ ] Refine the random respawn logic to **prevent new objects from spawning inside maze walls**.