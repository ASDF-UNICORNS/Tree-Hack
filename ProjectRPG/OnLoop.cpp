#include "Game.h"
#include "FPS.h"

void Game::OnLoop()
{
    CapFrameRate(60);

    //Gravity

    //Character.Gravity(WindowHeight);

    //Collisions

    //if(Character.CheckEntityColl(Block) ==  true)
    //{
    //    cout<<"Character is in collision with the Block"<<endl;
    //    Character.CanMove = false;
   // }
    //else
    //    Character.CanMove = true;

    //Cursor

    SDL_SetCursor(SDL_GetDefaultCursor());

    //Drag Entities with mouse
    //MouseDrag(&Block);
    //MouseDrag(&Character);

    if(MouseDragReset(&Cloud) == true)
    {
        water += Raining;

        if(chorbi > 5)
        {
            CreateKapka();
            chorbi = 0;
        }
    }

    chorbi ++;

    if(MouseDragReset(&Fertilizer) == true)
    {
        if(Fertilizer.XPos + 30 < lineX1)
            beenDrop = true;
    }
    else if(beenDrop == true)
    {
        fertilize += BeRiching;
        beenDrop = false;
    }

    fertilize -= Disolving;

    // Water Function
    water -= Drying;

    for(int i = 0; i < maxKapki; i ++)
    {
        Kapka[i].YPos += 6;

        if(Kapka[i].YPos > 430)
        {
            Kapka[i].falling = false;
        }
    }

    if(water < desert) water = desert;
    if(water > ocean) water = ocean;

    if(fertilize < 1) fertilize = 1;
    if(fertilize > 10) fertilize = 10;

    waterPointer.x = waterX * water;
    fertilizePointer.x = fertilizeX * fertilize;

    cout<<waterPointer.x<< " " << water<<endl;
    cout<<"Soil fertily "<<fertilize<<" "<<fertilizeX<<"  "<<fertilizePointer.x<<endl;

    for(int i = 0; i < 10; i ++)
    {
        if(Rubish[i].falling == true)
        {
            if(MouseDragReset(&Rubish[i]) == true)
            {
                int mouseX = 0;
                int mouseY = 0;

                SDL_GetMouseState(&mouseX, &mouseY);

                if(RecycleBin.Hover(mouseX, mouseY) == true)
                {
                    Rubish[i].falling = false;
                    dragOne = false;
                    Rubish[i].draggable = false;
                }
            }
            cout<<"Xpos: "<<Rubish[i].XPos<<" Ypos: "<<Rubish[i].YPos<<endl;
        }
    }

    if(timeRub == 200)
    {
        RandomRubbish();
        timeRub = 0;
    }

    cout<<timeRub<<endl;

    timeRub ++;

    int help = 4;
    MouseDrag(&Level[help]);
    cout<<Level[help].XPos<<" "<<Level[help].YPos<<endl;

}

void Game::MouseDrag(Entity *object)
{
    //Cursor on Hover

    if(dragOne == true && object->draggable == false)
        return;

    int mouseX = 0;
    int mouseY = 0;

    SDL_GetMouseState(&mouseX, &mouseY);

    if(object->Hover(mouseX, mouseY) == true)
    {
        SDL_SetCursor(Cursor);

        if(LeftButtonPressed == true)
            object->draggable = true;
    }

    if(LeftButtonPressed == false)
        object->draggable = false;

    if(object->draggable == true)
    {
        object->XPos = mouseX - object->Width / 2;
        object->YPos = mouseY - object->Height / 2;
        SDL_SetCursor(DragCursor);
        dragOne = true;
    }
    else
        dragOne = false;
}

bool Game::MouseDragReset(Entity *object)
{
    //Cursor on Hover

    if(dragOne == true && object->draggable == false)
        return false;

    int mouseX = 0;
    int mouseY = 0;

    SDL_GetMouseState(&mouseX, &mouseY);

    if(object->Hover(mouseX, mouseY) == true)
    {
        SDL_SetCursor(Cursor);

        if(LeftButtonPressed == true)
            object->draggable = true;
    }

    if(LeftButtonPressed == false)
        object->draggable = false;

    if(object->draggable == true)
    {
        object->XPos = mouseX - object->Width / 2;
        object->YPos = mouseY - object->Height / 2;
        SDL_SetCursor(DragCursor);
        dragOne = true;
        return true;
    }
    else
    {
        dragOne = false;
        object->XPos = object->defaultX;
        object->YPos = object->defaultY;
        return false;
    }

}

void Game::CreateKapka()
{
    if(Kapka[currentKapka].falling == false && Cloud.XPos + 30 < lineX1)
    {
        Kapka[currentKapka].CreateEntity(Cloud.XPos + 20, Cloud.YPos + 20, 20, 40);
        Kapka[currentKapka].falling = true;
        currentKapka ++;
    }

    if(currentKapka > 48)
    {
        currentKapka = 0;
    }
}

void Game::RandomRubbish()
{
    srand (time(NULL));

    int trashX = rand() % 470 + 30;
    int trashY = rand() % 240 + 200;
    int trashW = 0;
    int trashH = 0;

    int trash = rand() % 6 + 1;


    switch (trash)
    {
        case 1:
            Rubish[currentRubbish].Image = R1;
            trashW = 25;
            trashH = 50;
            break;
        case 2:
            Rubish[currentRubbish].Image = R2;
            trashW = 32;
            trashH = 43;
            break;
        case 3:
            Rubish[currentRubbish].Image = R3;
            trashW = 38;
            trashH = 45;
            break;
        case 4:
            Rubish[currentRubbish].Image = R4;
            trashW = 40;
            trashH = 43;
            break;
        case 5:
            Rubish[currentRubbish].Image = R5;
            trashW = 48;
            trashH = 60;
            break;
        case 6:
            Rubish[currentRubbish].Image = R6;
            trashW = 50;
            trashH = 47;
            break;
    }
    Rubish[currentRubbish].CreateEntity(trashX, trashY, trashW, trashH);
    Rubish[currentRubbish].falling = true;
    currentRubbish ++;
    if(currentRubbish == 10)
        currentRubbish = 0;
}
