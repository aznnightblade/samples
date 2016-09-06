// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "BaseWeapon.h"
#include "BaseGrenade.generated.h"

UENUM(BlueprintType)
enum class GrenadeType : uint8
{
	Semtex,
	Impact
};
/**
 * 
 */
UCLASS()
class CODENAMEBERMUDA_API ABaseGrenade : public ABaseWeapon
{
	GENERATED_BODY()
public:
	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "CodeNameBermuda | Stat")
		float m_Timer;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "CodeNameBermuda | Stat")
		float m_RadialDistance;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "CodeNameBermuda | Stat")
		GrenadeType m_GrenadeType;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "CodeNameBermuda | Stat")
		float m_FireRateMax;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "CodeNameBermuda | Stat")
		float m_FireRateCurr;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "CodeNameBermuda | State")
		bool m_CanFire;
	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = "CodeNameBermuda | State")
		bool m_IsGrenadeCheatOn;

	ABaseGrenade();

	virtual void Tick(float DeltaSeconds) override;

	

	UFUNCTION(BlueprintNativeEvent, BlueprintCallable, Category = "CodeNameBermuda | Events")
	void CreateGrenade();
	virtual void CreateGrenade_Implementation();

	UFUNCTION(BlueprintNativeEvent, BlueprintCallable, Category = "CodeNameBermuda | Events")
		void ThrowGrenade(FVector _Location, FRotator _Rotation);
	virtual void ThrowGrenade_Implementation(FVector _Location, FRotator _Rotation);
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

	// Called every frame

};


