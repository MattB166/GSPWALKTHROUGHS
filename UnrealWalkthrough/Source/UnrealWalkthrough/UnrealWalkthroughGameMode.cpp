// Copyright Epic Games, Inc. All Rights Reserved.

#include "UnrealWalkthroughGameMode.h"
#include "UnrealWalkthroughHUD.h"
#include "UnrealWalkthroughCharacter.h"
#include "UObject/ConstructorHelpers.h"

AUnrealWalkthroughGameMode::AUnrealWalkthroughGameMode()
	: Super()
{
	// set default pawn class to our Blueprinted character
	static ConstructorHelpers::FClassFinder<APawn> PlayerPawnClassFinder(TEXT("/Game/FirstPersonCPP/Blueprints/FirstPersonCharacter"));
	DefaultPawnClass = PlayerPawnClassFinder.Class;

	// use our custom HUD class
	HUDClass = AUnrealWalkthroughHUD::StaticClass();
}
