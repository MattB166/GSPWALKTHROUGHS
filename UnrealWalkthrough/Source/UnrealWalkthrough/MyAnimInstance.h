// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Animation/AnimInstance.h"
#include "MyAnimInstance.generated.h"

/**
 * 
 */
UCLASS()
class UNREALWALKTHROUGH_API UMyAnimInstance : public UAnimInstance
{
	GENERATED_BODY()

public:
	virtual void NativeInitializeAnimation() override;

	UFUNCTION(BlueprintCallable,Category = "CustomAnim")
		void customUpdateAnimation();

		UPROPERTY(BlueprintReadWrite, EditAnywhere,Category="CustomAnim")
		bool bIsInAir;

		UPROPERTY(BlueprintReadWrite,EditAnywhere,Category="CustomAnim")
		float moveSpeed;

		UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = "CustomAnim")
		class APawn* Pawn; 

	
};
