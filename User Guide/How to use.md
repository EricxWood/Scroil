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
