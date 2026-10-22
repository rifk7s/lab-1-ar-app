<div align="center">

<h1>VAR Product Viewer</h1>

<br/>

[![Unity][badge-unity]](https://unity.com/)
[![Vuforia][badge-vuforia]](https://developer.vuforia.com/)
[![Android][badge-android]](#android)
[![iOS][badge-ios]](#ios-sideload)
[![Git LFS][badge-lfs]](https://git-lfs.com/)

<br/>

An **Augmented Reality** product viewer built on an **image target**. Point your phone at the product card and a 3D model appears standing on it. Rotate it in any direction, zoom in and out, and switch models with the buttons.

</div>

> [!NOTE]
> Built for **Lab 5, Your First AR App: an Image-Target Product Viewer** (Unity + Vuforia Engine). Tracking uses **natural feature tracking**, so the card needs no special marker, just a picture with enough detail.
>
> **Only want to try the app?** Jump to [Install on your phone](#install-on-your-phone). You don't need Unity for that.

---

## Features

<table width="100%">
<thead>
<tr>
<th>Feature</th>
<th>How it works</th>
</tr>
</thead>
<tbody>
<tr><td><b>Image target tracking</b></td><td>Vuforia recognizes the card and computes its position and rotation (6DoF), then anchors the model on top of it.</td></tr>
<tr><td><b>Three 3D models</b></td><td>Beaver, bee and bunny. Only one is shown at a time.</td></tr>
<tr><td><b>Rotate in any direction</b></td><td>Drag one finger: horizontal drags spin the model like a turntable, vertical drags tilt it.</td></tr>
<tr><td><b>Zoom</b></td><td>Pinch with two fingers. Scale is clamped between 0.5x and 3x of the starting size.</td></tr>
<tr><td><b>UI buttons</b></td><td><code>&lt; Prev</code>, <code>Reset</code> and <code>Next &gt;</code>, plus a label with the model name and its position in the list.</td></tr>
<tr><td><b>UI follows the target</b></td><td>The hint "Point your camera at the product card" shows while the card is out of view. The buttons only appear while the card is detected.</td></tr>
</tbody>
</table>

### Controls

<table width="100%">
<thead>
<tr>
<th>Action</th>
<th>On a phone</th>
<th>In the Unity Editor (webcam)</th>
</tr>
</thead>
<tbody>
<tr><td><b>Rotate</b></td><td>Drag one finger</td><td>Left-click and drag</td></tr>
<tr><td><b>Zoom</b></td><td>Pinch with two fingers</td><td>Mouse scroll wheel</td></tr>
<tr><td><b>Switch model</b></td><td>Tap <code>&lt; Prev</code> or <code>Next &gt;</code></td><td>Click the button</td></tr>
<tr><td><b>Restore the view</b></td><td>Tap <code>Reset</code></td><td>Click <code>Reset</code></td></tr>
</tbody>
</table>

> [!TIP]
> Drags that start **on top of a button** are ignored on purpose, so tapping `Next` doesn't also spin the model.

---

## Target Card

The target database (`lab_db`) contains two images: `charliekirks` and `spongebobs`. The scene tracks **`charliekirks`**.

<div align="center">
<img src="Assets/Editor/Vuforia/ImageTargetTextures/lab_db/charliekirks_scaled.jpg" alt="The charliekirks target card" width="280">
</div>

Show the image above on a laptop or tablet screen, or print it, and point the camera at it.

> [!IMPORTANT]
> The models are designed for a card **lying flat on a table**. They stand on the card and face the bottom edge of it. If the card is shown **upright** (for example on a laptop screen), the model's up axis points at the camera, so you mostly see the top of the model. Drag to tilt it.

<details>
<summary>Tips for stable tracking</summary>

- Use bright, even lighting and avoid reflections on paper or screens.
- Matte paper works better than glossy paper.
- Don't cover more than half of the card. The more of the picture is hidden, the fewer feature points can be matched.
- Don't hold the card too far away or at a very steep angle. The feature points become too small or too skewed to match.
- Fast movement blurs the camera image and breaks tracking.

</details>

---

## Install on Your Phone

Grab the latest build with the direct links below, or browse every version on the **[Releases](https://github.com/rifk7s/lab-1-ar-app/releases)** page.

<table width="100%">
<thead>
<tr>
<th>Platform</th>
<th>File</th>
<th>Requirements</th>
</tr>
</thead>
<tbody>
<tr><td><b>Android</b></td><td><a href="https://github.com/rifk7s/lab-1-ar-app/releases/latest/download/ProductViewer.apk"><code>ProductViewer.apk</code></a></td><td>Android 10 (API 29) or newer, ARM64</td></tr>
<tr><td><b>iOS</b></td><td><a href="https://github.com/rifk7s/lab-1-ar-app/releases/latest/download/VARProductViewer-unsigned.ipa"><code>VARProductViewer-unsigned.ipa</code></a></td><td>iOS 15.0 or newer, <b>must be sideloaded</b>, Developer Mode turned on</td></tr>
</tbody>
</table>

<a id="android"></a>

### Android

1. Download [`ProductViewer.apk`](https://github.com/rifk7s/lab-1-ar-app/releases/latest/download/ProductViewer.apk) to your phone (or pick a version on the [Releases](https://github.com/rifk7s/lab-1-ar-app/releases) page).
2. Open the file. If asked, allow **Install unknown apps** for the browser or file manager you are using.
3. Install it, open **VAR Product Viewer** and allow camera access.
4. Point the camera at the target card.

> [!NOTE]
> This APK does not come from the Play Store, so Google Play Protect may show a warning. That is normal for APKs installed manually.

<a id="ios-sideload"></a>

### iOS (Sideload)

The IPA in Releases is **intentionally unsigned**. Apple doesn't allow installing apps from outside the App Store directly, so you need a sideloading tool that **re-signs the IPA with your own Apple ID**. A free Apple ID is enough.

> [!WARNING]
> With a free Apple ID, a sideloaded app is only valid for **7 days**. After that it won't open until you refresh or reinstall it. A free Apple ID is also limited to about **3 active sideloaded apps** at a time.

**Turn on Developer Mode first** (required on iOS 16 and later):

1. Open **Settings → Privacy & Security** and scroll to the bottom to find **Developer Mode**.
2. Switch it on. The phone will restart.
3. After it restarts, tap **Turn On** and enter your passcode.

> [!TIP]
> If the Developer Mode option isn't there, it usually shows up after the phone has run an app signed for development, for example after your first sideload.

<table width="100%">
<tr>
<td width="50%" valign="top">

#### With Sideloadly

[Sideloadly](https://sideloadly.io/) signs and installs the IPA over a USB cable. It runs on macOS and Windows.

1. Install Sideloadly on your computer.
2. Connect the iPhone with a USB cable and tap **Trust This Computer**.
3. Drag `VARProductViewer-unsigned.ipa` into the Sideloadly window.
4. Enter your **Apple ID** and click **Start**.
5. When it finishes, go to **Settings → General → VPN & Device Management**, pick your Apple ID and tap **Trust**.
6. Open the app and allow camera access.

</td>
<td width="50%" valign="top">

#### With AltStore

[AltStore](https://altstore.io/) installs and refreshes apps through **AltServer**, which runs on your computer.

1. Install **AltServer** on a Mac or Windows PC.
2. Install AltStore on the iPhone through AltServer (USB cable, or the same Wi-Fi network).
3. Open AltStore on the iPhone, go to **My Apps**, tap **+** and pick `VARProductViewer-unsigned.ipa`.
4. Trust your Apple ID profile under **Settings → General → VPN & Device Management**.
5. AltStore tries to refresh the app in the background before the 7 days run out, as long as the iPhone and the computer are on the same network.

</td>
</tr>
</table>

<details>
<summary>Why is the IPA unsigned?</summary>

A code signature contains the **name of the signing certificate**, and that name includes the email of the Apple ID that owns it. The `embedded.mobileprovision` file also holds a device ID and the Team ID. If an IPA signed with a personal Apple ID were uploaded to a public repo, anyone could read all of that.

So the IPA in Releases has its signature stripped: no `_CodeSignature`, no `embedded.mobileprovision`, and no signature on each binary. Sideloading tools re-sign it with the user's own Apple ID anyway, so the end result is the same for users.

An IPA signed by its author wouldn't work on other phones either, because its provisioning profile only allows registered devices.

</details>

<details>
<summary>Common sideloading problems</summary>

<table width="100%">
<thead>
<tr>
<th>Problem</th>
<th>Cause and fix</th>
</tr>
</thead>
<tbody>
<tr><td><b>Untrusted Developer</b> when opening the app</td><td>Go to <b>Settings → General → VPN &amp; Device Management</b>, pick your Apple ID and tap <b>Trust</b>.</td></tr>
<tr><td><b>Developer Mode</b> option is missing</td><td>Make sure you are on iOS 16 or newer. The option often only appears once a development app is installed.</td></tr>
<tr><td>App suddenly won't open</td><td>The 7 days are up. Refresh it in AltStore, or reinstall with Sideloadly.</td></tr>
<tr><td>Install fails because of the app limit</td><td>A free Apple ID is limited to about 3 active apps. Remove or deactivate another sideloaded app.</td></tr>
<tr><td>Black camera screen</td><td>Allow the camera under <b>Settings → VAR Product Viewer → Camera</b>.</td></tr>
<tr><td>Model shows up but you can't see its face</td><td>Lay the card flat on a table and view it from the bottom edge of the picture, at roughly 45 degrees.</td></tr>
</tbody>
</table>

</details>

---

## Run from Source

### Requirements

<table width="100%">
<thead>
<tr>
<th>Requirement</th>
<th>Version</th>
</tr>
</thead>
<tbody>
<tr><td><b>Unity</b></td><td>6000.6.5f1 (Unity 6). The project uses <b>URP</b>.</td></tr>
<tr><td><b>Vuforia Engine</b></td><td>11.4.4 (the <code>.tgz</code> package, see step 3)</td></tr>
<tr><td><b>Git LFS</b></td><td>Required. Models, target images and the font are stored with LFS. <a href="#1-install-git-lfs">How to install</a>.</td></tr>
<tr><td><b>Vuforia account</b></td><td>Free. You need it to get a license key (Basic plan).</td></tr>
<tr><td><b>Android Build Support</b></td><td>Optional, for Android builds (OpenJDK and Android SDK &amp; NDK modules)</td></tr>
<tr><td><b>Xcode</b></td><td>Optional, for iOS builds (macOS only)</td></tr>
</tbody>
</table>

> [!IMPORTANT]
> **Install Git LFS before you `git clone`.** Without it, the `.fbx`, `.png` and `.jpg` files are just small text pointers and the Unity project won't open correctly.

### Steps

<a id="1-install-git-lfs"></a>

**1. Install Git LFS (once per computer).** Git LFS is a separate program from Git, so having Git is not enough. Download it from [git-lfs.com](https://git-lfs.com/), or use your system's package manager:

<table width="100%">
<thead>
<tr>
<th>System</th>
<th>How to install</th>
</tr>
</thead>
<tbody>
<tr><td><b>Windows</b></td><td><a href="https://git-scm.com/download/win">Git for Windows</a> already includes Git LFS. Otherwise download the installer from <a href="https://git-lfs.com/">git-lfs.com</a>, or run <code>winget install GitHub.GitLFS</code> (or <code>choco install git-lfs</code> with Chocolatey).</td></tr>
<tr><td><b>macOS</b></td><td><code>brew install git-lfs</code> with <a href="https://brew.sh/">Homebrew</a>, or download the installer from <a href="https://git-lfs.com/">git-lfs.com</a>.</td></tr>
<tr><td><b>Linux</b></td><td>Debian / Ubuntu: <code>sudo apt install git-lfs</code><br>Fedora: <code>sudo dnf install git-lfs</code><br>Arch: <code>sudo pacman -S git-lfs</code><br>Other distros: see the <a href="https://github.com/git-lfs/git-lfs/blob/main/INSTALLING.md">official install guide</a>.</td></tr>
</tbody>
</table>

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

---

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

---

## How It Works

<details>
<summary>Tracking pipeline and scene hierarchy</summary>

**Four Vuforia stages:**

1. **Offline, in the Target Manager.** The image is analyzed into feature points (sharp corners and textured areas) and saved as a database (`lab_db.dat`).
2. **Detection, every frame.** The app finds feature points in the camera image and matches them against the database.
3. **Pose estimation.** Once enough points match, Vuforia computes the card's position and rotation (6DoF) relative to the camera. This is called *registration*.
4. **Tracking.** Those points are followed from frame to frame. On phones with ARCore or ARKit, device tracking can keep content in place briefly after the card leaves the view (the Extended Tracked status).

**Scene hierarchy:**

```
SampleScene
├── ARCamera
├── Directional Light
├── ProductCardTarget          (Image Target, Default Observer Event Handler)
│   └── ModelRoot              (ModelSwitcher + TouchManipulator, rotation Y = 180)
│       ├── animal-beaver
│       ├── animal-bee
│       └── animal-bunny
├── Canvas
│   ├── ControlsBar            (starts inactive, shown while the card is detected)
│   │   ├── PrevButton / ResetButton / NextButton
│   │   └── NameLabel
│   └── HintPanel              (shown while the card is out of view)
└── EventSystem
```

`ProductCardTarget` calls `SetActive` on `HintPanel` and `ControlsBar` through the **On Target Found** and **On Target Lost** events of the Default Observer Event Handler.

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
├── .gitattributes                     # Git LFS rules
└── .gitignore                         # Library, Builds, license key, Vuforia package, etc.
```

</details>

<details>
<summary>Notes on Git LFS in this repo</summary>

These binary files are stored with Git LFS (see `.gitattributes`):

- The `.fbx` 3D models and the `colormap.png` texture
- The `.jpg` target images
- The `LiberationSans.ttf` font and the template's bundled icon

On GitHub, LFS files look normal and carry a **Stored with Git LFS** label. To check on your own machine, run `git lfs ls-files --size`.

The `com.akryst.unity-discord-rpc` package in `Packages/manifest.json` is a personal Discord Rich Presence plugin and the app doesn't need it. It is safe to remove from `manifest.json` if you don't use it.

</details>

---

## Credits

The 3D models (`animal-beaver`, `animal-bee`, `animal-bunny`) and the `colormap.png` texture come from the **[Cube Pets](https://kenney.nl/assets/cube-pets)** pack by [Kenney](https://kenney.nl/), released under **[CC0 1.0](https://creativecommons.org/publicdomain/zero/1.0/)** (public domain). Attribution is not required, but it is appreciated.

---

## References

- [Vuforia Developer Library: Getting Started with Vuforia Engine in Unity](https://developer.vuforia.com/library/getting-started/getting-started-vuforia-engine-unity)
- [Vuforia Target Manager](https://developer.vuforia.com/library/vuforia-engine/getting-started/engine-developer-portal/vuforia-target-manager/)
- [AltStore FAQ](https://faq.altstore.io/)
- [Sideloadly](https://sideloadly.io/)
- [Expo: iOS Developer Mode](https://docs.expo.dev/guides/ios-developer-mode/)
- [Git LFS](https://git-lfs.com/)

<!-- Badge images (kept here so the top of the file stays readable) -->

[badge-unity]: https://img.shields.io/badge/Unity-6000.6-black?style=flat&labelColor=1a1a1a&logo=unity
[badge-vuforia]: https://img.shields.io/badge/Vuforia-11.4.4-blue?style=flat&labelColor=1a1a1a&logo=data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAMAAABEpIrGAAAADFBMVEUAAABWcFdOWFpuvkygZyG0AAAAAXRSTlMAQObYZgAAAIRJREFUOMuVU9ESwDAEE/7/n7drb51R0uVpR9AliHwBlQ46UOcxCWjLyyYaQNKRgh0BxfDcBDEQm%2BSWb40jTAntxoghEUahDSCI%2BnyoLaiPyxzu0ovinbOEr0u2Af4Q%2BhH0kfw3T4SKUkuWujGL2k0Xhq/cwdLytQ%2BU6rbI6Qk/3uWcwwWX8QSkvcueggAAAABJRU5ErkJggg%3D%3D
[badge-android]: https://img.shields.io/badge/Android-10%2B-3DDC84?style=flat&labelColor=1a1a1a&logo=android&logoColor=3DDC84
[badge-ios]: https://img.shields.io/badge/iOS-15%2B-lightgrey?style=flat&labelColor=1a1a1a&logo=apple&logoColor=white
[badge-lfs]: https://img.shields.io/badge/Git%20LFS-required-orange?style=flat&labelColor=1a1a1a&logo=git&logoColor=F05032
