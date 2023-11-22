// Fill out your copyright notice in the Description page of Project Settings.


#include "MyNinja.h"

// Sets default values
AMyNinja::AMyNinja()
{
 	// Set this character to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

}

// Called when the game starts or when spawned
void AMyNinja::BeginPlay()
{
	Super::BeginPlay();
	
}

// Called every frame
void AMyNinja::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}

// Called to bind functionality to input
void AMyNinja::SetupPlayerInputComponent(UInputComponent* PlayerInputComponent)
{
	Super::SetupPlayerInputComponent(PlayerInputComponent);

	PlayerInputComponent->BindAction("CustomKey", IE_Pressed, this, &AMyNinja::CustomKeyPress); 
}

void AMyNinja::CustomKeyPress()
{

	NinjaSMC = FindComponentByClass<USkeletalMeshComponent>();

	if (NinjaSMC)
	{
		NinjaSMC->PlayAnimation(NinjaJump, false);
	}
}

