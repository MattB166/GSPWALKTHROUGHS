// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Blueprint/UserWidget.h"
#include "MyUserWidget.generated.h"
DECLARE_DYNAMIC_MULTICAST_DELEGATE(FMyBindableEvent);

/**
 * 
 */
UCLASS()
class UNREALWALKTHROUGH_API UMyUserWidget : public UUserWidget
{
	GENERATED_BODY()

public:
	UFUNCTION(BlueprintCallable, Category = "Custom UI C++ Tutorials")
	void TestButtonClick();

	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "Custom UI C++ Tutorials")
	FString MyCustomTextProperty;
	
	UPROPERTY(BlueprintAssignable)
	FMyBindableEvent OnCustomFire;
};
