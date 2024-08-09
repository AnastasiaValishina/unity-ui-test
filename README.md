# Rewards Window and Tooltip Implementation

<p><strong>Unity Version:</strong> 2022.3.27f1</p>

<p><strong>Important!</strong> The tooltip close mechanism is implemented using <code>Input.touchCount</code> for mobile devices. To ensure it works correctly in Unity, it should be tested in <strong>Simulator mode</strong>.</p>

## Rewards Window

<p><strong>Mockup:</strong> <code>_ReferenceArt\screen_*.png</code></p>
<p><strong>Class:</strong> <code>RewardsWindow</code></p>

### Features:
<ul>
  <li>The window accepts a title and an array of items that the player receives as rewards.</li>
  <li>Each reward is displayed with its icon.</li>
  <li>The window stretches the list of items across the full width of the screen, with padding according to the layout.</li>
  <li>If the rewards fit on the screen, they are centered.</li>
  <li>If the rewards do not fit, they are aligned to the left with a scrollable area that has soft-clipping.</li>
</ul>

## Reward Tooltip
<p><strong>Mockup:</strong> <code>_ReferenceArt\tooltip_*.png</code></p>

### Functionality:
<ul>
  <li>A tooltip is displayed when a reward is long-tapped (the duration of the long tap can be made a constant in the code).</li>
  <li>The tooltip remains visible as long as the user is touching the screen (the user can move their finger across the screen, but the tooltip will disappear when the touch is released).</li>
</ul>

### Features:
<ul>
  <li>The tooltip has a minimum size (<code>tooltip_small.png</code>), even if the text is short.</li>
  <li>If there is a lot of text, the tooltip increases in height and width until it reaches the maximum size (<code>tooltip_big.png</code>). After that, the text inside the tooltip begins to auto-size.</li>
  <li>The tooltip displays: item name, description, and icon</li>
</ul>

