// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Character.h"
#include "MyCharacter.generated.h"

UENUM()
 enum Espells
{
	FireBall,
	ArcaneMissiles,
	FrostNova
};




UCLASS()
class UNREALWALKTHROUGH_API AMyCharacter : public ACharacter
{
	GENERATED_BODY()

public:
	// Sets default values for this character's properties
	AMyCharacter();

	UPROPERTY(VisibleAnywhere, Category = "Level Settings");
	float currentTime;
	UPROPERTY(EditAnywhere, Category = "Level Settings");
	float intervalTime; 
	UPROPERTY(EditAnywhere, Category = "Level Settings");
	FName NewLevel; 
	UPROPERTY(EditAnywhere)
    TEnumAsByte<Espells> Spellbook; 


	UPROPERTY(EditAnywhere, Category = "Spawner Category")
	TSubclassOf<AActor> ourSpawningObject; 
	 
	
	
	
	
protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;
	
	
	


public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;
   

	// Called to bind functionality to input
	virtual void SetupPlayerInputComponent(class UInputComponent* PlayerInputComponent) override;


	void InstantiateBalls(int amountToSpawn);

	FVector randPos();

};
