// Fill out your copyright notice in the Description page of Project Settings.


#include "GraphicsActor.h"
#include "NiagaraComponent.h"
#include "Components/MeshComponent.h"

// Sets default values
AGraphicsActor::AGraphicsActor()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

}

// Called when the game starts or when spawned
void AGraphicsActor::BeginPlay()
{
	Super::BeginPlay();

	UStaticMeshComponent* MySM = FindComponentByClass<UStaticMeshComponent>();
	MySM->SetMaterial(0, MyMat);

	
	

	MyDynamicMat = MySM->CreateAndSetMaterialInstanceDynamic(0);

	MyDynamicMat->SetVectorParameterValue(FName(TEXT("Colour")), FLinearColor(0, 0, 1, 1));


	UNiagaraComponent* MyNiagaraComp = FindComponentByClass<UNiagaraComponent>();

	MyNiagaraComp->SetColorParameter("MyColour", FLinearColor(0, 1, 0, 1));
}

// Called every frame
void AGraphicsActor::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
	//MyDynamicMat->SetVectorParameterValue(FName(TEXT("Colour")), FLinearColor(FMath::RandRange(0, 1), FMath::RandRange(0, 1), FMath::RandRange(0, 1), FMath::RandRange(0, 1)));

}

