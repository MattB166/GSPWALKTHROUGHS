// Fill out your copyright notice in the Description page of Project Settings.


#include "MyUserWidget.h"

void UMyUserWidget::TestButtonClick()
{
	OnCustomFire.Broadcast();
	
	//MyCustomTextProperty = TEXT("This is a test"); 
}
