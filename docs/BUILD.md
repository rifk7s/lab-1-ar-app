# Build and Run from Source

Back to the [README](../README.md).

## Run from Source

### Requirements

| Requirement | Version |
| --- | --- |
| **Unity** | 6000.6.5f1 (Unity 6). The project uses **URP**. |
| **Vuforia Engine** | 11.4.4 (the `.tgz` package, see step 3) |
| **Git LFS** | Required. Models, target images and the font are stored with LFS. [How to install](#1-install-git-lfs). |
| **Vuforia account** | Free. You need it to get a license key (Basic plan). |
| **Android Build Support** | Optional, for Android builds (OpenJDK and Android SDK & NDK modules) |
| **Xcode** | Optional, for iOS builds (macOS only) |

> [!IMPORTANT]
> **Install Git LFS before you `git clone`.** Without it, the `.fbx`, `.png` and `.jpg` files are just small text pointers and the Unity project won't open correctly.

### Steps

<a id="1-install-git-lfs"></a>

**1. Install Git LFS (once per computer).** Git LFS is a separate program from Git, so having Git is not enough. Download it from [git-lfs.com](https://git-lfs.com/), or use your system's package manager:

| System | How to install |
| --- | --- |
| **Windows** | [Git for Windows](https://git-scm.com/download/win) already includes Git LFS. Otherwise download the installer from [git-lfs.com](https://git-lfs.com/), or run `winget install GitHub.GitLFS` (or `choco install git-lfs` with Chocolatey). |
| **macOS** | `brew install git-lfs` with [Homebrew](https://brew.sh/), or download the installer from [git-lfs.com](https://git-lfs.com/). |
| **Linux** | Debian / Ubuntu: `sudo apt install git-lfs`<br>Fedora: `sudo dnf install git-lfs`<br>Arch: `sudo pacman -S git-lfs`<br>Other distros: see the [official install guide](https://github.com/git-lfs/git-lfs/blob/main/INSTALLING.md). |

Then check that it works and set it up. `git lfs install` only needs to run once per computer:

```bash
git lfs version     # should print something like: git-lfs/3.x.x
git lfs install     # one-time setup (prints "Git LFS initialized.")
```

> [!TIP]
> If `git lfs` says "command not found" right after installing, close and reopen your terminal so it picks up the new PATH.

**2. Clone the repo.**

```bash
git clone https://github.com/rifk7s/lab-1-ar-app.git
cd lab-1-ar-app
```

> [!NOTE]
> **Already cloned without Git LFS?** Install it as in step 1, then run `git lfs pull` inside the repo to replace the text pointers with the real files.

**3. Get the Vuforia Engine package.** From the [Vuforia Developer Portal](https://developer.vuforia.com/downloads/sdk), download the **Vuforia Engine package for Unity, version 11.4.4**, and put `com.ptc.vuforia.engine-11.4.4.tgz` inside the `Packages/` folder. The file is not in the repo on purpose (it is proprietary and large).

**4. Open the project in Unity Hub** with version **6000.6.5f1** and wait for the import to finish.

**5. Add your license key.** Select `ARCamera` in the Hierarchy, click **Open Vuforia Engine configuration** and paste your key into **App License Key**. You can generate a free key under **Plan & Licenses** in the Vuforia Developer Portal.

**6. Test with a webcam.** In the Vuforia configuration, set **Play Mode type** to **Webcam**, open `Assets/Scenes/SampleScene.unity`, press **Play** and point the card at your webcam.

> [!CAUTION]
> **Never commit your license key.** `Assets/Resources/VuforiaConfiguration.asset` contains your key and is already in `.gitignore`. The Vuforia `.tgz` package is ignored too.

<details>
<summary>Why aren't the Vuforia files in the repo?</summary>

- `VuforiaConfiguration.asset` holds a personal **license key**, so it must not go into a public repo. Unity creates it automatically in `Assets/Resources/`, and you only need to fill in your own key.
- The `com.ptc.vuforia.engine-11.4.4.tgz` package is about 130 MB and is proprietary SDK software from PTC. It is over GitHub's 100 MB per-file limit, and it is safer to download it straight from the source.
- `Packages/manifest.json` references it as `file:com.ptc.vuforia.engine-11.4.4.tgz`, so Unity can only resolve the package once that file is in `Packages/`.

</details>

## Build It Yourself

<table width="100%">
<tr>
<td width="50%" valign="top">

### Android

1. **File → Build Profiles**, pick **Android**, then **Switch Platform**.
2. Add the scene with **Add Open Scenes**.
3. Check the Player settings (already set in the repo):

| Setting | Value |
| --- | --- |
| Product Name | `VAR Product Viewer` |
| Package name | `com.rifky.productviewer` |
| Minimum API Level | Android 10 (API 29) |
| Scripting Backend | IL2CPP |
| Target Architectures | ARM64 |
| Orientation | Portrait |

4. Turn on **USB debugging** on the phone, connect it, then **Build And Run**.

</td>
<td width="50%" valign="top">

### iOS

1. **File → Build Profiles**, pick **iOS**, then **Switch Platform** and **Build** into `Builds/iOS`.
2. Open `Unity-iPhone.xcodeproj` in Xcode.
3. Under **Signing & Capabilities**, pick a **Team** and keep the Bundle Identifier `com.rifky.productviewer` (or change it to your own).
4. Pick your iPhone as the destination, then **Run**.
5. Deployment target is iOS 15.0. The camera usage text is already set: "Camera is used for AR Tracking".

</td>
</tr>
</table>

<details>
<summary>Make an unsigned IPA from the Xcode build</summary>

Once the app builds, take `VARProductViewer.app` from `DerivedData` (the `Build/Products/ReleaseForRunning-iphoneos/` folder) and run the following from the folder that contains it.

```bash
# 1. Create the Payload folder and copy the app into it
mkdir -p ipa/Payload
cp -R VARProductViewer.app ipa/Payload/

# 2. Remove the provisioning profile and every _CodeSignature folder
rm -f ipa/Payload/VARProductViewer.app/embedded.mobileprovision
find ipa/Payload -name _CodeSignature -type d -prune -exec rm -rf {} +

# 3. Strip the signature from every Mach-O binary
find ipa/Payload -type f -exec sh -c 'file "$1" | grep -q Mach-O && codesign --remove-signature "$1"' _ {} \;

# 4. Zip it into an IPA
(cd ipa && zip -qry ../VARProductViewer-unsigned.ipa Payload)
```

Then check that none of your account data is left. Replace `your-apple-id-email` with your own Apple ID email. Every command below should print nothing, except the last one, which should only print `not signed` lines:

```bash
unzip -q VARProductViewer-unsigned.ipa -d check

# No signing leftovers
find check -name embedded.mobileprovision -o -name _CodeSignature

# No Apple ID email, certificate names or entitlements
grep -rl -a "your-apple-id-email" check
grep -rl -a -E "Apple Development|Apple Distribution|iPhone Developer" check
grep -rl -a -E "TeamIdentifier|application-identifier|get-task-allow" check

# Every Mach-O binary should say "not signed"
find check -type f -exec sh -c 'file "$1" | grep -q Mach-O && codesign -d "$1" 2>&1' _ {} \;
```

Delete the `check` folder when you are done. The `Builds/` folder is in `.gitignore`, so `.apk` and `.ipa` files are never committed.

</details>

## Project Reference

<details>
<summary>Notes on Git LFS in this repo</summary>

These binary files are stored with Git LFS (see `.gitattributes`):

- The `.fbx` 3D models and the `colormap.png` texture
- The `.jpg` target images
- The `LiberationSans.ttf` font and the template's bundled icon

On GitHub, LFS files look normal and carry a **Stored with Git LFS** label. To check on your own machine, run `git lfs ls-files --size`.

The `com.akryst.unity-discord-rpc` package in `Packages/manifest.json` is a personal Discord Rich Presence plugin and the app doesn't need it. It is safe to remove from `manifest.json` if you don't use it.

</details>

<details>
<summary>Project structure</summary>

```
lab-1-ar-app/
├── Assets/
│   ├── _Project/
│   │   ├── Models/                    # animal-beaver, animal-bee, animal-bunny (.fbx) + colormap.png
│   │   └── Scripts/
│   │       ├── ModelSwitcher.cs       # Show one model, Next / Previous, name label
│   │       └── TouchManipulator.cs    # Rotate, tilt, zoom, ResetView
│   ├── Scenes/
│   │   └── SampleScene.unity          # ARCamera, ProductCardTarget, ModelRoot, Canvas
│   ├── Editor/
│   │   ├── Migration/                 # Vuforia package migration script
│   │   └── Vuforia/ImageTargetTextures/lab_db/   # Target images (charliekirks, spongebobs)
│   ├── StreamingAssets/Vuforia/       # lab_db.dat + lab_db.xml (target database)
│   ├── Resources/                     # VuforiaConfiguration.asset (ignored, holds the license key)
│   ├── Settings/                      # URP assets and build profiles
│   └── TextMesh Pro/                  # TMP fonts and shaders
├── Packages/
│   └── manifest.json                  # Package dependencies (put the Vuforia tgz here by hand)
├── ProjectSettings/                   # Android and iOS Player settings
├── docs/
│   └── BUILD.md                       # Build and run from source guide
├── .gitattributes                     # Git LFS rules
└── .gitignore                         # Library, Builds, license key, Vuforia package, etc.
```

</details>
