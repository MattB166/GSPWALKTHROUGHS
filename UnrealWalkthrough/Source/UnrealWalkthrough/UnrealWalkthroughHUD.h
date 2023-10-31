// Copyright Epic Games, Inc. All Rights Reserved.

#pragma once 

#include "CoreMinimal.h"
#include "GameFramework/HUD.h"
#include "UnrealWalkthroughHUD.generated.h"

UCLASS()
class AUnrealWalkthroughHUD : public AHUD
{
	GENERATED_BODY()

public:
	AUnrealWalkthroughHUD();

	/** Primary draw call for the HUD */
	virtual void DrawHUD() override;

private:
	/** Crosshair asset pointer */
	class UTexture2D* CrosshairTex;

};

