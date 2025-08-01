# Scroil

Scroil is a Windows tool that enables smooth and customizable mouse wheel scrolling system-wide, giving you a better scrolling experience in browsers, code editors, and other software.

---

## Try It Out

Go to the [Releases](https://github.com/EricxWood/Scroil/releases) section of this repository and download the core algorithm demo program.  
Run the program to experience the smooth scrolling effect powered by Scroil.

---

## Planned Features

1. **Low-Level High-Precision Mouse Driver**  
   Develop a custom driver to simulate a high-precision mouse.  
   This will replace the current testing method (`SendInput()`), providing even better compatibility and smoother scroll experience.

2. **App Scroll Behavior Classifier**  
   Build a module that can classify applications based on whether they natively support smooth scrolling or not.  
   This helps Scroil to apply the best scroll algorithm for each app automatically.

3. **User Interface (UI)**  
   Design and implement a software UI, making it easy for users to configure and control Scroil’s features without editing config files.
