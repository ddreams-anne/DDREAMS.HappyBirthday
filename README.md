# DDREAMS.HappyBirthday
A Unity 6 project by Anne CH Postma, D:DREAMS Studio

## ABOUT
In December 2024 my mother became 80. To celebrate this, I created a little online birthday celebration project. After I finished it, I decided to clean it up and make it publicly available on GitHub. The project contains two scenes:

1) **Fijne Verjaardag**
    this scene ...
    - plays a typical Dutch Northern Brabant song (AI generated)
    - has 99 balloons (a playful reference to 99 Luftballons by Nena) in original Dutch flag and pennant colors floating upwards
    - display Dutch happy birthday texts in random order at certain intervals
2) **Happy Birthday**
    this scene ...
    - plays 5 happy birthday songs (AI generated) in random order
    - has 99 (a playful reference to 99 Luftballons by Nena) emoji balloons floating upwards
    - display happy birthday texts (out of 225 languages) in random order at certain intervals

## SCRIPTS (worth mentioning)

### BalloonLogic
Using the BalloonLogic script you can add materials to a specific balloon prefab, which will be randomly picked each time a new balloon gets instantiated. This way, you can have a variety of balloons, using just one prefab.

### BalloonSpawner
It is possible to add more balloon (or other) prefabs to the BalloonSpawner component and randomly float them upwards. You can specify how many balloons will be instantiated and the min and max values for the spawn interval time.

### RandomTextSwitcher
The random text switcher will display a random text from a list of text strings at a specific time interval. You can change/provide the text list containing the random texts and change/set the interval time.

## CREDITS

The unlicense agreement for my personal work will not apply to the following assets. Their own license agreement still applies!

* [Indian Smile Balloon model](https://www.fab.com/listings/5556398a-f791-4101-bd30-ee9153047cdc) by [Chirag Moolya](https://www.fab.com/sellers/chirag%20Moolya) @ [FAB](https://www.fab.com/)
* [Parkinsans font](https://fonts.google.com/specimen/Parkinsans) @ [Google Fonts](https://fonts.google.com/)

## CONTACT

Feel free to contact me via GitHub or LinkedIn if you have questions, suggestions or requests. However, I will only react to positive feedback and friendly questions.<br>All trolling will be ignored.
