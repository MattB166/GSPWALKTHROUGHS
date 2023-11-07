// Fill out your copyright notice in the Description page of Project Settings.


#include "MyCharacter.h"
#include "Kismet/GameplayStatics.h"

// Sets default values
AMyCharacter::AMyCharacter()
{
 	// Set this character to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

}

// Called when the game starts or when spawned
void AMyCharacter::BeginPlay()
{
	Super::BeginPlay();
	GLog->Log("Custom Message");

	
	

	//OurNewObj->SetLifeSpan(3);
	//GLog->Log("Actor destroyed");
	
}

// Called every frame
void AMyCharacter::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

	currentTime += DeltaTime;

	if (currentTime > intervalTime)
	{
		//UGameplayStatics::OpenLevel(GetWorld(), NewLevel);
	}
	
	
	GLog->Log("Time is" + FString::SanitizeFloat(DeltaTime));
	
	InstantiateBalls(1);
}

// Called to bind functionality to input
void AMyCharacter::SetupPlayerInputComponent(UInputComponent* PlayerInputComponent)
{
	Super::SetupPlayerInputComponent(PlayerInputComponent);

}

void AMyCharacter::InstantiateBalls(int amount)
{
	for (int i = 0; i < amount; i++)
	{
		FActorSpawnParameters spawnParams;

		spawnParams.Owner = this;
		spawnParams.Instigator = GetInstigator();

		AActor* ourNewObj = GetWorld()->SpawnActor<AActor>(ourSpawningObject, randPos(), FRotator(0), spawnParams);
	}
}

FVector AMyCharacter::randPos()
{
	return FVector(FMath::RandRange(-1000, 1000), FMath::RandRange(-1000, 1000), FMath::RandRange(-1000, 1000));
}
	

	





