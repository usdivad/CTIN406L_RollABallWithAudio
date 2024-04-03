# Roll-A-Ball-With-Audio

Roll-A-Ball, now with sound! For USC course CTIN 406L: Sound Design for Games.

Based on Unity's [Roll-A-Ball tutorial](https://learn.unity.com/project/roll-a-ball), adapting the [completed project files](https://assetstore.unity.com/packages/essentials/tutorial-projects/unity-learn-roll-a-ball-completed-project-files-urp-77198) and adding newly implemented audio.

## Week 10 Reference: Physics of Audio in Games
1. [Download the `week10-physics` version of the project](https://github.com/usdivad/CTIN406L_RollABallWithAudio/archive/refs/heads/week10-physics.zip)
2. You may want to look at the following files:
	- Unity:
		- Assets/Scenes/Week10_Physics.unity
		- Assets/Scripts/Gameplay/Interactable.cs
	- Wwise:
		- CTIN406L_RollABallWithAudio_WwiseProject
			- In \Master-Mixer Hierarchy\Default Work Unit\Master Audio Bus\RVB:
				- RVB_EarlyReflections
				- RVB_Room
			- \Interactive Music Hierarchy\Default Work Unit\MUS_BGM_Interactive

## Week 9 Reference: Digital Signal Processing & Audio Effects
1. [Download the `week9-effects` version of the project](https://github.com/usdivad/CTIN406L_RollABallWithAudio/archive/refs/heads/week9-effects.zip)
2. You may want to look at the following files:
	- Unity:
		- Assets/Scenes/Week9_Effects.unity
		- Assets/Scripts/Gameplay/Helmet.cs
		- Assets/Scripts/Audio/HelmetAudioComponent.cs
	- Wwise:
		- CTIN406L_RollABallWithAudio_WwiseProject
			- Effects on AMB, MUS, SFX buses in the Master-Mixer Hierarchy
			- \Effects\Default Work Unit\FX_HelmetDistortion

## Week 8 Reference: Interactive Music Approaches
1. [Download the `week8-interactive-music` version of the project](https://github.com/usdivad/CTIN406L_RollABallWithAudio/archive/refs/heads/week8-interactive-music.zip)
2. You may want to look at the following files:
	- Unity:
		- Assets/Scenes/Week8_InteractiveMusic.unity
		- Assets/Scripts/Audio/PlayerMovementAudioComponent.cs
		- Assets/Scripts/Audio/BallAudioComponent.cs
	- Wwise:
		- CTIN406L_RollABallWithAudio_WwiseProject
			- \Interactive Music Hierarchy\Default Work Unit\MUS_BGM_Interactive

## Week 7 Reference: Dynamically Driven Audio
1. [Download the `week7-dynamically-driven-audio` version of the project](https://github.com/usdivad/CTIN406L_RollABallWithAudio/archive/refs/heads/week7-dynamically-driven-audio.zip)
2. The following may be helpful for **Project 2 - Footsteps**:
	- Unity:
		- Assets/Scripts/Audio/PlayerFootstepAudioComponent.cs
		- Assets/Scripts/Audio/TimerBasedFootstepAudioTrigger.cs
		- Assets/Scenes/Week7_Footsteps_FirstPerson.unity
		- Assets/Scenes/Week7_Footsteps_ThirdPerson.unity
	- Wwise (project at CTIN406L_RollABallWithAudio_WwiseProject):
		- \Actor-Mixer Hierarchy\Default Work Unit\FLY\FLY_Footstep

## Week 6 Reference: Middleware
1. [Download the `week6-middleware` version of the project](https://github.com/usdivad/CTIN406L_RollABallWithAudio/archive/refs/heads/week6-middleware.zip)
2. You may want to look at the following files:
	- Unity:
		- Assets/Scenes/Week6_Middleware.unity
		- Assets/Scripts/Audio/PlayerAudioComponent.cs
	- Wwise:
		- CTIN406L_RollABallWithAudio_WwiseProject

## Week 6 Reference: Ambience Cont.
1. [Download the `week6-ambiences-cont` version of the project](https://github.com/usdivad/CTIN406L_RollABallWithAudio/archive/refs/heads/week6-ambiences-cont.zip) and open Assets/Scenes/Week6_AmbienceCont.unity
2. These scripts in Assets/Scripts/Audio may be helpful for **Project 1 - Ambience**:
	- RandomEmitter.cs

##  Week 5 Reference: Ambience
1. [Download the `week5-ambiences` version of the project](https://github.com/usdivad/CTIN406L_RollABallWithAudio/archive/refs/heads/week5-ambiences.zip) and open Assets/Scenes/Week5_Ambience.unity
2. These scripts in Assets/Scripts/Audio may be particularly helpful for **Project 1**:
	- DistanceBasedAmbienceZone.cs
	- TriggerBasedAmbienceZone.cs

## Week 4 Assignment: Audio Replacement
1. [Download the `week4-implementation` version of the project](https://github.com/usdivad/CTIN406L_RollABallWithAudio/archive/refs/heads/week4-implementation.zip) and open Assets/Scenes/RollABallWithAudio.unity
2. **Replace all existing audio** with new sound assets that you create
3. (Optional) **Implement new audio** where there previously was none
	- Some ideas:
		- VO for each pickup that matches the current pickup count
		- A third sound zone with new looping ambience
		- Fading out the music once the player wins
4. **Create a Windows build**, zip it, and upload the zip using the form provided in class
5. Come to class prepared to share and discuss with everyone!

## Dependencies
- [Unity LTS 2022.3.18f1](https://unity.com/releases/lts)
- [Wwise 2023.1.1](https://www.audiokinetic.com/download/)
