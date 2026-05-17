# Scroil

Scroil is a smooth-scrolling extension for Windows that makes mouse wheel scrolling feel more natural, consistent, and customizable.

## Features
* **Global Smooth Scrolling:** Brings smoother mouse wheel scrolling across your apps on Windows, reducing the jumpy feeling of apps's default scrolling behavior.

| Scroil OFF (Windows Default) | Scroil ON (Smooth) |
| :---: | :---: |
| <video src="https://github.com/user-attachments/assets/c1b38a43-d146-450c-b62d-84c7ee192f41" autoplay loop muted playsinline></video> | <video src="https://github.com/user-attachments/assets/7e8140ef-c5f2-43f7-ae84-b33d7e9c860e" autoplay loop muted playsinline></video> |

<br>

- **Optimized for High-Refresh-Rate Displays:** Scroil is built for extremely high-refresh-rate screens, with a backend polling rate of 1000 Hz, similar to a gaming mouse. High-refresh-rate displays are not just for games anymore; Scroil helps make everyday web browsing and app scrolling feel smoother too. Actual visible smoothness may still be limited by the app's own GUI framework or rendering engine, especially if that app cannot render at the display's full refresh rate.

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
  
- **App Picker & Per-App Control:** Add currently open programs to your Scroil profile list, customize scrolling experience for each app.
  <p align="center">
  <img width="635" height="598" alt="App Profiles" src="https://github.com/user-attachments/assets/aba6c290-85e4-4823-b419-26ff6f8429c0" />
  </p>

  <br>
  
- **Auto App Classifier:** Automatically recognizes Chromium-based apps, including Teams, Discord, Outlook and others, then applies the right scrolling config for that app type.
  <p align="center">
  <img width="2816" height="1536" alt="Auto App Classifier" src="https://github.com/user-attachments/assets/32dcfe50-e15c-42fb-ad3b-4c571411f57b" />
  </p>

  <br>

- **Game Detection:** Recognizes games automatically and turn off smooth scroll for games to avoid interfering with your gameplay.
  <p align="center">
  <img width="1609" height="916" alt="Game Detection" src="https://github.com/user-attachments/assets/10afbbb7-cea1-446a-bd58-4c1140408f04" />
  </p>


## Supported Apps

Scroil includes built-in support for common Windows apps.

| App |
| --- |
| VS Code <img src="https://code.visualstudio.com/assets/favicon.ico" alt="VS Code icon" width="16" height="16"> |
| WeChat <img src="https://www.wechat.com/favicon.ico" alt="WeChat icon" width="16" height="16"> |
| Chrome <img src="https://www.google.com/chrome/static/images/favicons/favicon-32x32.png" alt="Chrome icon" width="16" height="16"> |
| Files <img src="https://files.community/branding/logo-light.svg" alt="Files icon" width="16" height="16"> |
| Microsoft Word <img src="https://res.cdn.office.net/files/fabric-cdn-prod_20230815.002/assets/brand-icons/product/svg/word_48x1.svg" alt="Microsoft Word icon" width="16" height="16"> |
| Microsoft Excel <img src="https://res.cdn.office.net/files/fabric-cdn-prod_20230815.002/assets/brand-icons/product/svg/excel_48x1.svg" alt="Microsoft Excel icon" width="16" height="16"> |
| Firefox <img src="https://www.firefox.com/media/img/favicons/firefox/browser/favicon-196x196.59e3822720be.png" alt="Firefox icon" width="16" height="16"> |
| Apple Music <img src="https://music.apple.com/assets/favicon/favicon-32.png" alt="Apple Music icon" width="16" height="16"> |
| Microsoft Edge <img src="https://edgecdn-embza6g8cacagcbn.z01.azurefd.net/welcome/static/favicon.png" alt="Microsoft Edge icon" width="16" height="16"> |

Scroil also supports almost all mainstream Electron, WebView, and Chromium-based apps through automatic app classification. Examples include Microsoft Teams <img src="https://res.cdn.office.net/files/fabric-cdn-prod_20230815.002/assets/brand-icons/product/svg/teams_48x1.svg" alt="Microsoft Teams icon" width="16" height="16">, Discord <img src="https://cdn.prod.website-files.com/6257adef93867e50d84d30e2/62fddf0fde45a8baedcc7ee5_847541504914fd33810e70a0ea73177e%20(2)-1.png" alt="Discord icon" width="16" height="16">, Outlook <img src="https://res.cdn.office.net/files/fabric-cdn-prod_20230815.002/assets/brand-icons/product/svg/outlook_48x1.svg" alt="Outlook icon" width="16" height="16">, Notion <img src="https://www.notion.com/front-static/favicon.ico" alt="Notion icon" width="16" height="16">, Tidal <img src="https://tidal.com/favicon.ico" alt="Tidal icon" width="16" height="16">, Spotify <img src="https://open.spotifycdn.com/cdn/images/favicon32.b64ecc03.png" alt="Spotify icon" width="16" height="16">, and other browser-based desktop apps.

### Current Restrictions

Some apps are currently unsupported, including File Explorer and many older desktop apps. These apps often use older or system-level scrolling behavior that does not provide reliable pixel-wise scrolling precision, so Scroil cannot smooth them safely yet.

Electron, WebView, and Chromium-based apps are supported, but the experience may not be perfect in every app. Many of these apps already apply their own internal smooth scrolling, so Scroil has to work around that built-in behavior.


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
