# Scroil

Scroil is a smooth-scrolling extension for Windows that makes mouse wheel scrolling feel more natural, consistent, and customizable.

## Features
* **Global Smooth Scrolling:** Brings smoother mouse wheel scrolling across your apps on Windows, reducing the jumpy feeling of apps's default scrolling behavior.

| Scroil OFF (Windows Default) | Scroil ON (Smooth) |
| :---: | :---: |
| <video src="https://github.com/user-attachments/assets/c1b38a43-d146-450c-b62d-84c7ee192f41" autoplay loop muted playsinline></video> | <video src="https://github.com/user-attachments/assets/7e8140ef-c5f2-43f7-ae84-b33d7e9c860e" autoplay loop muted playsinline></video> |

<br>

- **Custom Scroll Feel:** Adjust speed, step size, acceleration, deacceleration, and fine-grained scroll behavior.
  <p align="center">
  <img width="282" height="474" alt="Custom Scroll Feel" src="https://github.com/user-attachments/assets/8f2f6aa6-e339-47e0-8091-ff9e12eec219" />
</p>

<br>

- **Scrolling Accelerator:** Increases scroll speed during faster wheel movement, making long pages easier to move through.

| Scroil OFF (Windows Default) | Scroil ON (Scroll hundreds of lines in a second with the same natural wheel motion) |
| :---: | :---: |
| <video src="https://github.com/user-attachments/assets/c10b28f3-9c43-4d22-a353-5d78de22c060" autoplay loop muted playsinline></video> | <video src="https://github.com/user-attachments/assets/de6181d6-89f2-4d00-8772-a4bfa84bf226" autoplay loop muted playsinline></video>

<br>
  
- **App Picker & Per-App Control:** Add currently open apps to your Scroil profile list, customize scrolling experience for each app.
  <p align="center">
  <img width="635" height="598" alt="App Profiles" src="https://github.com/user-attachments/assets/aba6c290-85e4-4823-b419-26ff6f8429c0" />
  </p>

  <br>
  
- **Auto App Classifier:** Automatically recognizes apps of the same types, like Chromium-based apps, including Teams, Discord, Outlook and others, then applies the right scrolling config for that app type.
  <p align="center">
  <img width="2816" height="1536" alt="Auto App Classifier" src="https://github.com/user-attachments/assets/32dcfe50-e15c-42fb-ad3b-4c571411f57b" />
  </p>

  <br>

- **Game Detection:** Recognizes games automatically and turn off smooth scroll for games to avoid interfering with your gameplay.
  <p align="center">
  <img width="1609" height="916" alt="Game Detection" src="https://github.com/user-attachments/assets/10afbbb7-cea1-446a-bd58-4c1140408f04" />
  </p>



## OS and Hardware Requirements

Scroil has been verified working on Windows 10 and Windows 11. It may need a reasonably responsive system for the best smooth-scrolling experience, and the effect is more noticeable on high-refresh-rate displays.

## Important Note for VS Code, Chrome, Edge, and Firefox Users

To get the best result with Scroil, turn off built-in smooth scrolling in apps that already apply their own smooth-scroll effect. Otherwise, their own scrolling behavior can conflict with Scroil.

### Chrome

1. Open Chrome.
2. In the address bar, enter:

```text
chrome://flags/#smooth-scrolling
```

3. Set `Smooth Scrolling` to `Disabled`.
4. Relaunch Chrome.

### Edge

1. Open Edge.
2. In the address bar, enter:

```text
edge://flags/#smooth-scrolling
```

3. Set `Smooth Scrolling` to `Disabled`.
4. Relaunch Edge.

### Firefox

1. Open Firefox.
2. Open Settings.
3. Go to `General` > `Browsing`.
4. Turn off `Use smooth scrolling`.
5. If you cannot find it, enter `about:config` in the address bar, search for `general.smoothScroll`, and set it to `false`.

### VS Code

1. Open VS Code.
2. Open Settings.
3. Search for `smooth scrolling`.
4. Turn off `Editor: Smooth Scrolling`.
5. If needed, also turn off smooth scrolling in any extensions or custom settings that re-enable it.
