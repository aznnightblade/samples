// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "EnemyBase.h"
#include "RangeBase.generated.h"

/**
 * 
 */
UCLASS()
class CODENAMEBERMUDA_API ARangeBase : public AEnemyBase
{
	GENERATED_BODY()

public:
	

		ARangeBase();
		virtual void BeginPlay() override;
	
		virtual void Tick(float DeltaSeconds) override;

		// Called to bind functionality to input
		virtual void SetupPlayerInputComponent(class UInputComponent* InputComponent) override;


		UFUNCTION(BlueprintCallable, Category = Delegates, BlueprintImplementableEvent)
		void FireProjectile();
};
