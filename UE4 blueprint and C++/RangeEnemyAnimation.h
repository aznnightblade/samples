// Fill out your copyright notice in the Description page of Project Settings.

#pragma once


#include "BaseAnimation.h"
#include "RangeEnemyAnimation.generated.h"

DECLARE_DYNAMIC_MULTICAST_DELEGATE(FSpawnProjectile);

/**
 * 
 */


UCLASS()
class CODENAMEBERMUDA_API URangeEnemyAnimation : public UBaseAnimation
{
	GENERATED_BODY()
	
public:
	

		UPROPERTY(BlueprintAssignable, BlueprintCallable, Category = "Codename Bermuda | Stats")
		FSpawnProjectile SpawnProjectile;
	
};

