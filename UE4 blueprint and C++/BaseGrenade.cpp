// Fill out your copyright notice in the Description page of Project Settings.

#include "CodenameBermuda.h"
#include "BaseGrenade.h"


ABaseGrenade::ABaseGrenade()
{
	m_FireRateMax = 5;
	m_FireRateCurr = 0;
	m_CanFire = true;
}

void ABaseGrenade::BeginPlay()
{
	Super::BeginPlay();

}

void ABaseGrenade::Tick(float DeltaSeconds)
{
	Super::Tick(DeltaSeconds);

	m_FireRateCurr -= DeltaSeconds;

	if (m_FireRateCurr <= 0.0f)
		m_CanFire = true;
}

void ABaseGrenade::ThrowGrenade_Implementation(FVector _Location, FRotator _Rotation)
{


}



void ABaseGrenade::CreateGrenade_Implementation()
{

}