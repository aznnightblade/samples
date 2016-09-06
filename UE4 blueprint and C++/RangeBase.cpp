// Fill out your copyright notice in the Description page of Project Settings.

#include "CodenameBermuda.h"
#include "RangeBase.h"
#include "RangeEnemyAnimation.h"



ARangeBase::ARangeBase()
{
	// Set this character to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

}


// Called every frame
void ARangeBase::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}

// Called to bind functionality to input
void ARangeBase::SetupPlayerInputComponent(class UInputComponent* InputComponent)
{
	Super::SetupPlayerInputComponent(InputComponent);

}


void ARangeBase::BeginPlay()
{
	Super::BeginPlay();


	USkeletalMeshComponent* mesh = GetMesh();
	if (mesh)
	{
		URangeEnemyAnimation* baseAnimation = Cast<URangeEnemyAnimation>(mesh->GetAnimInstance());
		if (baseAnimation)
		{
			baseAnimation->SpawnProjectile.AddDynamic(this, &ARangeBase::FireProjectile);
		}
	}
}

