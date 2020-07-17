using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class wizard
{
    public string wizardName;
    public float height;
    public int age;
}

 

/* From python file
yourName = input('What is your name? ')
yourHeight = input('What is your height? ')
yourAge = input('How old are you? ')

player = wizard(yourName, yourHeight, yourAge)
enemy = wizard('Gandalf', 120, 2019)

Full python file:
import pygame
import time

# Pygame Setup
pygame.display.set_caption('Gandalf the Brown')
win = pygame.display.set_mode((500, 500))

clock = pygame.time.Clock()

screenWidth = 500
screenHeight = 480

def redrawGameWindow():
    global walkCount 

    win.blit((0,0))  


# Player Setup
yourName = input('What is your name? ')
yourHeight = input('What is your height? ')
yourAge = input('How old are you? ')

class wizard(object):
    def __init__(self, name, height, age, x, y):
        self.name = name 
        self.height = height
        self.age = age
        self.x = x
        self.y = y
        self.vel = 5
        self.isJump = False
        self.jumpCount = 10
        self.left = False
        self.right = False
        self.walkCount = 0 
        self.standing = True 

player = wizard(yourName, yourHeight, yourAge)
enemy = wizard('Gandalf', 120, 2019)

run = True

while run == True:
     if keys[pygame.K_SPACE]:
        if player.left:
            facing = -1 
        else:
            facing = 1
    #pass

*/