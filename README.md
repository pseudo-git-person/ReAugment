# ReAugment
Augmented Reality Application developped in Unity using C#.
It's available on Play Store, I'll share the link in due time.

Used packages/plugins are:
ARFoundation.
LeanTouch

The furniture models I used are available here: 
https://assetstore.unity.com/packages/3d/props/furniture/hdrp-furniture-pack-153946
all credit goes to the original author of theses models.

Below are links to some of the sites I found very helpful in the process of developpment of my first Augmented Reality mobile application:
https://docs.unity3d.com/Manual/XR.html
https://developers.google.com/ar/develop/unity-arf/getting-started-ar-foundation
https://learn.unity.com/project/ar-hello-world
https://github.com/Unity-Technologies/arfoundation-samples
https://carloswilkes.com/Documentation/LeanTouch
https://learn.unity.com/tutorial/manipulating-objects-in-ar-with-lean-touch?uv=2019.4#

A quick overview of the functionality:
The app uses ARPlaneManager in order to detect trackable planes that can be used for object placements.
If there is one available the app waits for user input in the form of a finger touch after selecting a furniture to be placed.
The objects can be moved, made bigger or smaller or rotated in the Y axis with finger slide, pinch or pinch slide respectively. This functionality is available with the use of LeanTouch scripts.
There are two toggle buttons for hiding/showing tracked planes and for hiding/showing the UI menu for clearer visibility.
There is also a button that allows the user to remove all of the previously placed objects.
