# Scroil

Scroil is a Windows scrolling enhancement project built to make mouse-wheel scrolling feel smoother, more controllable, and more consistent across the apps you use every day.

The project combines:

- A native backend that intercepts wheel input and renders smoother scroll output.
- A desktop frontend that lets you manage settings, app profiles, diagnostics, and runtime behavior without digging through source code.

## Why Use Scroil

Scroil is for people who want scrolling to feel less abrupt and more natural on Windows, especially in software where default mouse-wheel behavior feels too jumpy or inconsistent.

You may want Scroil if you care about:

- Smoother wheel scrolling in browsers, editors, file explorers (planned feature), and other desktop apps.
- Per-app behavior instead of one global scroll style for everything.
- Faster tuning of step size, acceleration, and deceleration.
- A project that is actively moving toward smarter app detection and better compatibility.

## Current Beta Snapshot

The current combined desktop beta pairs:

- Frontend: `beta 1.0.7`
- Backend: `beta 1.0.1`

Current work already includes:

- A Windows desktop frontend for editing and applying scroll settings.
- Runtime config, default config, and setting-range validation.
- App-aware scroll profiles, including default and per-app behavior.
- Open-window app discovery and on-screen window picking.
- System tray support.
- Game detection support.
- Frontend diagnostics, crash-dump capture, and log severity filtering.
- Backend algorithm tuning and performance-focused updates.

## GUI Basics

Scroil's desktop app is built around profiles. A profile is a set of scrolling settings that Scroil can apply to a specific app.

### Default Profile

The `default` profile is your baseline. It is used when an app does not have its own custom profile.

If you want Scroil to feel better everywhere first, tune the default profile before creating lots of app-specific profiles.

### App Profiles

An app profile is a custom set of scrolling settings for one app.

Use an app profile when:

- One app feels better with different tuning than your general setup.
- An app scrolls too fast, too slow, too sharply, or too softly.
- You want different behavior for browsers, editors, file explorers, or games.

### How Profiles Work

Scroil can detect apps and apply the matching profile automatically. If no matching app profile exists, Scroil falls back to the default profile.

This means you can keep:

- One general profile for most software
- Special profiles only for apps that need them

### Main Settings

The most important profile settings are:

- `step_size`: how much scrolling power each wheel step contributes
- `acceleration_duration`: how quickly scrolling ramps up
- `deacceleration_duration`: how long scrolling eases out
- `enabled`: whether Scroil should actively control scrolling for that profile

In simple terms:

- Higher `step_size` usually feels stronger or faster.
- Shorter acceleration usually feels more immediate.
- Longer deceleration usually feels smoother and floatier.

### Adding A Profile

You can add app-specific profiles by:

- Choosing from currently open windows
- Using the on-screen window picker

That makes it easier to target the exact app you want without manually typing process names.

### Important Compatibility Note

Some apps already have their own smooth-scrolling behavior. In those apps, built-in smooth scrolling can conflict with Scroil.

If scrolling feels doubled, overly delayed, or inconsistent, turn off the app's own smooth-scrolling feature first, especially in:

- Chrome
- Edge
- VS Code

## Project Direction

Scroil is moving toward a desktop experience where smooth scrolling is:

- Easier to configure.
- More reliable across different apps.
- More adaptive to the app currently under the cursor.
- Better instrumented when something goes wrong.

The long-term goal is to make Scroil feel less like a prototype and more like a practical Windows utility for people who care about input quality.

## Roadmap

### Near-Term

1. Improve release polish for the packaged desktop build.
2. Keep tightening metadata detection, app discovery, and frontend stability.
3. Refine default profiles so first-run behavior feels better with less manual tuning.
4. Expand diagnostics so crashes, backend restarts, and config issues are easier to trace.

### Next

1. Make app classification smarter so Scroil can choose stronger defaults automatically.
2. Improve per-app profile management and profile editing flow inside the frontend.
3. Continue compatibility testing for browsers, editors, file explorers, launchers, and games.
4. Add better onboarding so users understand setup, browser conflicts, and recommended defaults faster.

### Longer-Term

1. Explore higher-precision injection paths beyond the current wheel-output approach.
2. Build a more advanced app behavior model for smooth-scroll compatibility and special-case handling.
3. Add import/export and preset-sharing options for scroll profiles.
4. Push the project closer to a stable general-use Windows release.

## Try It Out

You can download builds from the [Releases](https://github.com/EricxWood/Scroil/releases) section of the repository.

If you are testing a pre-release:

- Expect active iteration.
- Expect configuration and compatibility to keep improving between builds.
- Use the desktop frontend to tune behavior instead of treating the defaults as final.

## Notes

- Scroil is currently focused on Windows.
- Browser-native smooth scrolling can still conflict with Scroil in some cases.
- This project is still in beta, so polish and compatibility are improving alongside core functionality.
