# 🎮 Modular 3D Character Controller for Unity

A clean, robust, and professional modular 3D Character Controller built from scratch in Unity. Designed with a strict separation of concerns, this project leverages **Unity's New Input System**, **ScriptableObjects** for data-driven configuration, and a clean **state-managed architecture** without relying on complex, bloated state-machine frameworks.

---

## ⚡ Key Features

* 🚀 **New Input System Integration**: Uses modern Unity input handling for smooth, responsive movement and action reading.
* 🎛️ **Fully Configurable Speeds & Physics**: Fine-tune movement mechanics directly in Unity with granular control over:
  * **Walk Speed** (Ground movement)
  * **Air Speed** (Air control & momentum)
  * **Jump Speed**
  * **Custom Gravity**
* 🎯 **Precise SphereCast Ground Detection**: Reliable ground checking using a `SphereCast` targeted strictly at the `Ground` layer to handle slopes and edges cleanly.
* 📷 **Integrated Camera System**: Smooth follow mechanics and clamped mouse-look rotation managed by a dedicated camera script.
* 📦 **Data-Driven Architecture**: Easily tweak parameters across levels using reusable ScriptableObject assets.

---

## 🛠️ System Architecture & Components

The project is split into distinct, highly modular components, each handling a single responsibility:

* **`PlayerController`**
  The orchestrator that brings everything together. Assembles movement, physics execution in `FixedUpdate`, ground detection, and state logic into a complete, ready-to-use character controller.

* **`PlayerConfig`**
  A `ScriptableObject` data asset storing all tweakable parameters (`walkSpeed`, `airSpeed`, `jumpSpeed`, `gravity`, etc.), decoupling configuration values from runtime code.

* **`PlayerState`**
  Defines the active physical states of the player: `isOnGround`, `isOnAir`, and `isJumping`.

* **`PlayerStateManager`**
  Handles state evaluation and activation rules. Sets `isJumping` the moment a jump is executed, transitions to `isOnAir` while airborne (applying air speed controls), and switches to `isOnGround` when not jumping and ground contact is confirmed.

* **`PlayerGroundCheck`**
  Performs environmental checks using a `SphereCast` specifically looking for the **`Ground`** layer to verify if the character is grounded.

* **`PlayerInput`**
  Communicates with Unity's New Input System, fetching raw input action values (movement vector, look vector, jump button) for the controller to process.

* **`CameraManager`**
  Attached directly to the camera. Manages pitch (up/down) clamping and yaw (left/right) rotation driven by mouse input, while smoothly keeping the camera position aligned with the player.

---

## 🚀 Setup Instructions

1. **Configure the Ground Layer**:
   * Ensure a layer named **`Ground`** exists in your Unity project settings.
   * Assign all walkable terrain, floors, and platforms to the **`Ground`** layer.

2. **Create a Player Config Asset**:
   * Right-click in the Project Window and create a `PlayerConfig` ScriptableObject asset.
   * Set your desired values for **Walk Speed**, **Air Speed**, **Jump Speed**, and **Gravity**.

3. **Assemble the Character**:
   * Attach Unity's standard `CharacterController` component to your Player GameObject.
   * Attach `PlayerController`, `PlayerInput`, `PlayerStateManager`, and `PlayerGroundCheck`.
   * Drag your `PlayerConfig` asset into the corresponding field on the `PlayerController`.

4. **Set Up the Camera**:
   * Attach `CameraManager` to your Main Camera.
   * Assign the Player GameObject as the target for position tracking and configure your mouse sensitivity.

**P.S.**
Absolutely NO content of this project is AI generated.
