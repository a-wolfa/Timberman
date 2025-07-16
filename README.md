# Unity Timber Game Project

## 1. Overview

This project is a fast-paced, arcade-style game where the player controls a lumberjack chopping down an infinitely generating tree. The core gameplay loop involves switching sides to chop the tree while avoiding branches, all under the pressure of a constantly depleting timer.

The architecture is built to be highly modular, scalable, and maintainable, leveraging several powerful design patterns and the Zenject dependency injection framework.

---

## 2. Core Architecture & Design Patterns

The project's foundation relies on a combination of modern software design patterns to ensure a clean separation of concerns.

### Key Pillars:

- **Dependency Injection (DI) with Zenject**  
  The entire project is built around Zenject. Dependencies are not fetched manually; they are *injected* into classes via their constructors. This decouples classes from each other and makes the codebase incredibly flexible and easy to test. Bindings are managed through a set of focused Installers.

- **ECS-like System Architecture**  
  At the heart of the game loop is a custom Entity-Component-System-style architecture:
  - **Systems (BaseSystem):** These are classes that contain pure logic (e.g., `MovementSystem`, `TimerSystem`). They operate every frame.
  - **Data (BaseData):** These are simple data containers (e.g., `InputData`, `TimerData`) that hold the state systems operate on. They are cleared of frame-specific data at the end of each update.
  - **SystemContainer:** This central class manages the lifecycle of all systems. It activates, updates, and deactivates systems based on requests, following a specific frame-by-frame flow to ensure predictability.

- **State Pattern for Game Flow**  
  The overall game flow (e.g., Theme Selection → Ready → Playing → Death) is managed by a classic State Machine.
  - `GameStateController` is the context that manages the current state.
  - `BaseGameSate` implementations (`ReadySate`, `PlayingState`, etc.) contain the specific logic for each phase of the game.

- **Signal Bus for Decoupled Communication**  
  Instead of classes calling each other directly, they communicate through a global `SignalBus`.
  - When an important event happens (e.g., a tree segment is chopped), a signal like `ChoppedSignal` is "fired".
  - Other classes (like `ScorePresenter` or `AudioService`) can subscribe to these signals and react without knowing who fired the event. This dramatically reduces coupling.

- **Strategy Pattern for Swappable Logic**  
  The project uses the Strategy Pattern to allow for different behaviors to be swapped out easily.
  - `IInputStrategy` (`KeyboardInputStrategy`, `TouchInputStrategy`) allows the input method to change based on the platform.
  - `IThrow` (`DoThrow`, `RbThrow`) allows the physics behavior of chopped tree segments to be changed.

- **Factory Pattern & Object Pooling**  
  - **Factories** (`PlayerFactory`, `TreeFactory`) are responsible for creating complex objects, especially those requiring asynchronous loading of assets via Addressables.
  - **Memory Pools** (`TreeSegmentPool`) are used for frequently created and destroyed objects like tree segments. This avoids garbage collection and significantly improves performance.

- **Model-View-Presenter (MVP) for UI**  
  The UI logic is separated using the MVP pattern:
  - **Model (`ScoreService`)**: Holds the raw data and business logic.
  - **View (`ScoreView`)**: The MonoBehaviour that displays the data. It is "dumb" and only does what the presenter tells it.
  - **Presenter (`ScorePresenter`)**: Mediates between the model and the view. It listens for signals, updates the model, and formats the data for the view.

---

## 3. Module Breakdown

### Installers

The `Installers` directory contains Zenject `MonoInstaller` classes. Their only job is to bind dependencies to the DI container.

- `SceneContextInstaller`: Binds concrete instances from the scene (e.g., UI elements, transforms) and project-wide ScriptableObject configuration files.
- `CoreSystemsInstaller`: Binds the foundational architecture: the signal bus, all systems, and all data containers.
- `GameplayInstaller`: Binds gameplay-related logic like controllers, services, strategies, and presenters.
- `GameStateInstaller`: Binds the game state machine classes.
- `PlayerInstaller` & `TreeInstaller`: Bind factories specific to the player and the tree.

### Configuration (ScriptableObjects)

All game balance values ("magic numbers") are stored in ScriptableObject assets, which are bound in the `SceneContextInstaller`.

- `GameBalanceConfig.cs`: Contains values for the timer, tree generation, etc.
- `ThrowConfig.cs`: Contains physics values for the different throw strategies.

### Systems & Data

Located in the `Systems` directory:

- `InputSystem`: Consumes input signals and populates `InputData`.
- `MovementSystem`: Moves the player based on `InputData`.
- `ChoppingSystem`: Chops a tree segment when activated.
- `TreeManagementSystem`: Generates and manages the tree segments.
- `TimerSystem`: Manages the game timer and fires an expiry signal.
- `AnimationSystem`: Controls player animations based on input.

---

## 4. Project Setup in Unity

### 1. Prerequisites

- Unity **2021.3 or later**
- **Zenject**: Import the latest version from the Asset Store or via UPM.
- **DOTween**: Import the latest version from the Asset Store.
- Unity's **Input System Package**: Install via the Package Manager.
- Unity's **Addressables Package**: Install via the Package Manager.

### 2. Create Configuration Assets

- In the Project window:
  - Right-click → **Create > Game > Game Balance Config** → Name it `DefaultGameBalance`.
  - Right-click → **Create > Game > Throw Configuration** → Name it `DefaultThrowConfig`.
- Select these assets and adjust their values in the Inspector.

### 3. Set Up the Scene

- Create a new, empty scene.
- Create an empty GameObject and name it `SceneContext`.
- Add the following `MonoInstaller` components to the `SceneContext` GameObject:
  - `SceneContextInstaller`
  - `CoreSystemsInstaller`
  - `GameplayInstaller`
  - `GameStateInstaller`
  - `PlayerInstaller`
  - `TreeInstaller`

### 4. Assign References

- Select the `SceneContext` GameObject.
- In the Inspector, under `SceneContextInstaller`, assign:
  - Your `InputActionAsset`.
  - The parent `Transform` for the tree.
  - The main `AudioSource`.
  - The `TextMeshProUGUI` for the score display.
  - The `AudioClip` for the chop sound.
  - The `DefaultGameBalance` and `DefaultThrowConfig` assets.

### 5. Hit Play

The game should now run, with Zenject wiring up all dependencies correctly.
