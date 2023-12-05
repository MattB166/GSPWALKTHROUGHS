// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "Materials/Material.h"
#include "Components/MeshComponent.h"
#include "Materials/MaterialInstanceDynamic.h"

#include "GraphicsActor.generated.h"

UCLASS()
class UNREALWALKTHROUGH_API AGraphicsActor : public AActor
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	AGraphicsActor();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

	UPROPERTY(EditAnywhere)
	UMaterialInstance* MyMat;
	
	UPROPERTY(EditAnywhere)
	UMaterial* MyMat2;

	UMaterialInstanceDynamic* MyDynamicMat;



	

};
