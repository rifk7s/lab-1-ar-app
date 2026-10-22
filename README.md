<div align="center">

<h1>VAR Product Viewer</h1>

[![Unity][badge-unity]](https://unity.com/)
[![Vuforia][badge-vuforia]](https://developer.vuforia.com/)
[![Android][badge-android]](#android)
[![iOS][badge-ios]](#ios-sideload)
[![Git LFS][badge-lfs]](https://git-lfs.com/)

An **Augmented Reality** product viewer built on an **image target**. Point your phone at the product card and a 3D model appears standing on it. Rotate it in any direction, zoom in and out, and switch models with the buttons.

</div>

> [!NOTE]
> Built for **Lab 5, Your First AR App: an Image-Target Product Viewer** (Unity + Vuforia Engine).
>
> **Only want to try the app?** Jump to [Install on Your Phone](#install-on-your-phone). You don't need Unity for that.

<details>
<summary><b>Features</b></summary>

Tracking uses **natural feature tracking**, so the card needs no special marker, just a picture with enough detail.

| Feature | How it works |
| --- | --- |
| **Image target tracking** | Vuforia recognizes the card and computes its position and rotation (6DoF), then anchors the model on top of it. |
| **Three 3D models** | Beaver, bee and bunny. Only one is shown at a time. |
| **Rotate in any direction** | Drag one finger: horizontal drags spin the model like a turntable, vertical drags tilt it. |
| **Zoom** | Pinch with two fingers. Scale is clamped between 0.5x and 3x of the starting size. |
| **UI buttons** | `< Prev`, `Reset` and `Next >`, plus a label with the model name and its position in the list. |
| **UI follows the target** | The hint "Point your camera at the product card" shows while the card is out of view. The buttons only appear while the card is detected. |

</details>

## Controls

| Action | On a phone | In the Unity Editor (webcam) |
| --- | --- | --- |
| **Rotate** | Drag one finger | Left-click and drag |
| **Zoom** | Pinch with two fingers | Mouse scroll wheel |
| **Switch model** | Tap `< Prev` or `Next >` | Click the button |
| **Restore the view** | Tap `Reset` | Click `Reset` |

> [!TIP]
> Drags that start **on top of a button** are ignored on purpose, so tapping `Next` doesn't also spin the model.

## Target Card

The target database (`lab_db`) contains two images: `charliekirks` and `spongebobs`. The scene tracks **`charliekirks`**.

<div align="center">
<img src="Assets/Editor/Vuforia/ImageTargetTextures/lab_db/charliekirks_scaled.jpg" alt="The charliekirks target card" width="220">
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

## Install on Your Phone

Grab the latest build with the direct links below, or browse every version on the **[Releases](https://github.com/rifk7s/lab-1-ar-app/releases)** page.

| Platform | File | Requirements |
| --- | --- | --- |
| **Android** | [`ProductViewer.apk`](https://github.com/rifk7s/lab-1-ar-app/releases/latest/download/ProductViewer.apk) | Android 10 (API 29) or newer, ARM64 |
| **iOS** | [`VARProductViewer-unsigned.ipa`](https://github.com/rifk7s/lab-1-ar-app/releases/latest/download/VARProductViewer-unsigned.ipa) | iOS 15.0 or newer, **must be sideloaded**, Developer Mode turned on |

<a id="android"></a>

### Android

1. Download the APK from the table above to your phone.
2. Open the file. If asked, allow **Install unknown apps** for the browser or file manager you are using.
3. Install it, open **VAR Product Viewer** and allow camera access.
4. Point the camera at the target card.

> [!NOTE]
> This APK does not come from the Play Store, so Google Play Protect may show a warning. That is normal for APKs installed manually.

<a id="ios-sideload"></a>

### iOS (Sideload)

iOS builds must be sideloaded with your own Apple ID. Open the guide below.

<details>
<summary><b>iOS sideload guide</b></summary>

The IPA in Releases is **intentionally unsigned**. Apple doesn't allow installing apps from outside the App Store directly, so you need a sideloading tool that **re-signs the IPA with your own Apple ID**. A free Apple ID is enough.

> **Warning:** With a free Apple ID, a sideloaded app is only valid for **7 days**. After that it won't open until you refresh or reinstall it. A free Apple ID is also limited to about **3 active sideloaded apps** at a time.

**Turn on Developer Mode first** (required on iOS 16 and later):

1. Open **Settings → Privacy & Security** and scroll to the bottom to find **Developer Mode**.
2. Switch it on. The phone will restart.
3. After it restarts, tap **Turn On** and enter your passcode.

> **Tip:** If the Developer Mode option isn't there, it usually shows up after the phone has run an app signed for development, for example after your first sideload.

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

| Problem | Cause and fix |
| --- | --- |
| **Untrusted Developer** when opening the app | Go to **Settings → General → VPN & Device Management**, pick your Apple ID and tap **Trust**. |
| **Developer Mode** option is missing | Make sure you are on iOS 16 or newer. The option often only appears once a development app is installed. |
| App suddenly won't open | The 7 days are up. Refresh it in AltStore, or reinstall with Sideloadly. |
| Install fails because of the app limit | A free Apple ID is limited to about 3 active apps. Remove or deactivate another sideloaded app. |
| Black camera screen | Allow the camera under **Settings → VAR Product Viewer → Camera**. |
| Model shows up but you can't see its face | Lay the card flat on a table and view it from the bottom edge of the picture, at roughly 45 degrees. |

</details>

</details>

## For Developers

Want to build from source? See [docs/BUILD.md](docs/BUILD.md) (install Git LFS before you clone).

<details>
<summary>How it works</summary>

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

## Credits

The 3D models (`animal-beaver`, `animal-bee`, `animal-bunny`) and the `colormap.png` texture come from the **[Cube Pets](https://kenney.nl/assets/cube-pets)** pack by [Kenney](https://kenney.nl/), released under **[CC0 1.0](https://creativecommons.org/publicdomain/zero/1.0/)** (public domain). Attribution is not required, but it is appreciated.

<details>
<summary>References</summary>

- [Vuforia Developer Library: Getting Started with Vuforia Engine in Unity](https://developer.vuforia.com/library/getting-started/getting-started-vuforia-engine-unity)
- [Vuforia Target Manager](https://developer.vuforia.com/library/vuforia-engine/getting-started/engine-developer-portal/vuforia-target-manager/)
- [AltStore FAQ](https://faq.altstore.io/)
- [Sideloadly](https://sideloadly.io/)
- [Expo: iOS Developer Mode](https://docs.expo.dev/guides/ios-developer-mode/)
- [Git LFS](https://git-lfs.com/)

</details>

<!-- Badge images (kept here so the top of the file stays readable) -->

[badge-unity]: https://img.shields.io/badge/Unity-6000.6-black?style=flat&labelColor=1a1a1a&logo=unity
[badge-vuforia]: https://img.shields.io/badge/Vuforia-11.4.4-blue?style=flat&labelColor=1a1a1a&logo=data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAMAAABEpIrGAAAADFBMVEUAAABWcFdOWFpuvkygZyG0AAAAAXRSTlMAQObYZgAAAIRJREFUOMuVU9ESwDAEE/7/n7drb51R0uVpR9AliHwBlQ46UOcxCWjLyyYaQNKRgh0BxfDcBDEQm%2BSWb40jTAntxoghEUahDSCI%2BnyoLaiPyxzu0ovinbOEr0u2Af4Q%2BhH0kfw3T4SKUkuWujGL2k0Xhq/cwdLytQ%2BU6rbI6Qk/3uWcwwWX8QSkvcueggAAAABJRU5ErkJggg%3D%3D
[badge-android]: https://img.shields.io/badge/Android-10%2B-3DDC84?style=flat&labelColor=1a1a1a&logo=android&logoColor=3DDC84
[badge-ios]: https://img.shields.io/badge/iOS-15%2B-lightgrey?style=flat&labelColor=1a1a1a&logo=apple&logoColor=white
[badge-lfs]: https://img.shields.io/badge/Git%20LFS-required-orange?style=flat&labelColor=1a1a1a&logo=git&logoColor=F05032
