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
