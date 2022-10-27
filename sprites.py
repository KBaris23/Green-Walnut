
import pygame
from config import *
import math
import random
class Player(pygame.sprite.Sprite):
    def __init__(self,game, x,y):
        #self.image = pygame.image.load("Player_Sprite_R.png")
        self.game=game
        self._layer=PLAYER_LAYER
        self.groups=self.game.all_sprites
        pygame.sprite.Sprite.__init__(self, self.groups)
        # Position and direction
        self.x=x*TILESIZE
        self.y=y*TILESIZE
        self.width=TILESIZE
        self.height=TILESIZE
        self.image=pygame.Surface([self.width, self.height])
        self.x_change=0
        self.y_change=0
        self.facing='down'
        self.image.fill(BLUE)
        self.rect=self.image.get_rect()
        self.rect.x=self.x
        self.rect.y=self.y
    def update(self):
        self.movement()
        self.collide_enemy()
        self.collide_bouncer()
        self.rect.x+=self.x_change
        self.collide_detect('x')
        self.rect.y+=self.y_change
        self.collide_detect('y')


        self.x_change=0
        self.y_change=0
    def movement(self):
        keys=pygame.key.get_pressed()
        left, right, middle=pygame.mouse.get_pressed()
        if keys[pygame.K_LEFT]:
            self.x_change -= PLAYER_SPEED
            self.facing='left'
        if keys[pygame.K_RIGHT]:
            self.x_change += PLAYER_SPEED
            self.facing='right'
        if keys[pygame.K_UP]:
            self.y_change -= PLAYER_SPEED
            self.facing='up'
        if keys[pygame.K_DOWN]:
            self.y_change += PLAYER_SPEED
            self.facing='down'
        if left:
            if self.y_change>0:
                self.y_change+=ACCELERATION
            if self.x_change>0:
                self.x_change+=ACCELERATION
            if self.y_change<0:
                self.y_change-=ACCELERATION
            if self.x_change<0:
                self.x_change-=ACCELERATION
    def collide_detect(self,direction):
        if direction=='x':
            hits=pygame.sprite.spritecollide(self, self.game.blocks, False)
            if hits:
                if self.x_change>0:
                    self.rect.x=hits[0].rect.left- self.rect.width
                if self.x_change<0:
                    self.rect.x=+hits[0].rect.right

        if direction=='y':
            hits=pygame.sprite.spritecollide(self, self.game.blocks, False)
            if hits:
                if self.y_change>0:
                    self.rect.y=hits[0].rect.top-self.rect.height
                if self.y_change<0:
                    self.rect.y=hits[0].rect.bottom
    def collide_enemy(self):
        hits=pygame.sprite.spritecollide(self, self.game.enemies, False)
        if hits:
            self.kill()
    def collide_bouncer(self):
        hits=pygame.sprite.spritecollide(self, self.game.bouncer, False)
        if hits:
            if self.x_change!=0:
                self.x_change=-self.x_change
            if self.y_change!=0:
                self.y_change=-self.y_change

class Block(pygame.sprite.Sprite):
    def __init__(self, game, x,y):
        #self.image = pygame.image.load("Player_Sprite_R.png")
        self.game=game
        self._layer=BLOCK_LAYER
        self.groups= self.game.all_sprites, self.game.blocks
        pygame.sprite.Sprite.__init__(self, self.groups)
        # Position and direction
        self.x=x*TILESIZE
        self.y=y*TILESIZE
        self.width=TILESIZE
        self.height=TILESIZE
        self.image=pygame.Surface([self.width, self.height])
        self.image.fill(GREEN)
        self.rect=self.image.get_rect()
        self.rect.x=self.x
        self.rect.y=self.y
        #pygame.font.init() # you have to call this at the start, 
                   # if you want to use this module.
        #my_font = pygame.font.SysFont('Comic Sans MS', 30)
        #text_surface = my_font.render('Some Text', False, (0, 0, 0))
        #screen.blit(text_surface, (0,0))

class Grass(pygame.sprite.Sprite):
    def __init__(self, game, x,y):
        #self.image = pygame.image.load("Player_Sprite_R.png")
        self.game=game
        self._layer=BLOCK_LAYER
        self.groups= self.game.all_sprites, self.game.grass
        pygame.sprite.Sprite.__init__(self, self.groups)
        # Position and direction
        self.x=x*TILESIZE
        self.y=y*TILESIZE
        self.width=TILESIZE
        self.height=TILESIZE
        self.image=pygame.Surface([self.width, self.height])
        self.image.fill(GREEN_LIGHT)
        self.rect=self.image.get_rect()
        self.rect.x=self.x
        self.rect.y=self.y
class SettingScreen(pygame.sprite.Sprite):
    def __init__(self, game, x,y):
        #self.image = pygame.image.load("Player_Sprite_R.png")
        self.game=game
        self._layer=BLOCK_LAYER
        self.groups= self.game.all_sprites, self.game.grass
        pygame.sprite.Sprite.__init__(self, self.groups)
        # Position and direction
        self.x=x*TILESIZE
        self.y=y*TILESIZE
        self.width=TILESIZE
        self.height=TILESIZE
        self.image=pygame.Surface([self.width, self.height])
        self.image.fill((250,250,150))
        self.rect=self.image.get_rect()
        self.rect.x=self.x
        self.rect.y=self.y
class Enemy(pygame.sprite.Sprite):
    def __init__(self, game, x,y):
        #self.image = pygame.image.load("Player_Sprite_R.png")
        self.game=game
        self._layer=BLOCK_LAYER+1
        self.groups= self.game.all_sprites, self.game.enemies
        pygame.sprite.Sprite.__init__(self, self.groups)
        # Position and direction
        self.x=x*TILESIZE
        self.y=y*TILESIZE
        self.width=TILESIZE
        self.height=TILESIZE
        self.image=pygame.Surface([self.width, self.height])
        image_to_load=pygame.image.load("New Piskel 1.png")
        self.image.blit(image_to_load, (0,0))
        
 
        self.image.set_colorkey(BLACK)
        self.rect=self.image.get_rect()
        self.rect.x=self.x
        self.rect.y=self.y
class pit(pygame.sprite.Sprite):
    def __init__(self, game, x,y):
        #self.image = pygame.image.load("Player_Sprite_R.png")
        self.game=game
        self._layer=BLOCK_LAYER+1
        self.groups= self.game.all_sprites, self.game.pit
        pygame.sprite.Sprite.__init__(self, self.groups)
        # Position and direction
        self.x=x*TILESIZE
        self.y=y*TILESIZE
        self.width=TILESIZE
        self.height=TILESIZE
        self.image=pygame.Surface([self.width, self.height])
        image_to_load=pygame.image.load("New Piskel3.png")
        self.image.blit(image_to_load, (0,0))
        
 
        self.image.set_colorkey(BLACK)
        self.rect=self.image.get_rect()
        self.rect.x=self.x
        self.rect.y=self.y
    def update(self):
        pygame.display.update()
    def collide_detect(self):

        hits=pygame.sprite.spritecollide(self, self.game.all_sprites, False)
        if hits:
            Player.kill(self)
class pit1(pygame.sprite.Sprite):
    def __init__(self, game, x,y):
        #self.image = pygame.image.load("Player_Sprite_R.png")
        self.game=game
        self._layer=BLOCK_LAYER+1
        self.groups= self.game.all_sprites, self.game.pit
        pygame.sprite.Sprite.__init__(self, self.groups)
        # Position and direction
        self.x=x*TILESIZE
        self.y=y*TILESIZE
        self.width=TILESIZE
        self.height=TILESIZE
        self.image=pygame.Surface([self.width, self.height])
        image_to_load=pygame.image.load("New Piskel  3.png")
        self.image.blit(image_to_load, (0,0))
        self.rect=self.image.get_rect()
        self.rect.x=self.x
        self.rect.y=self.y
        self.image.set_colorkey(BLACK)
        self.rect=self.image.get_rect()
        self.rect.x=self.x
        self.rect.y=self.y
    def update(self):
        pygame.display.update()
    def collide_detect(self):

        hits=pygame.sprite.spritecollide(self, self.game.all_sprites, False)
        if hits:
            Player.kill(self)
class Bouncer(pygame.sprite.Sprite):
    def __init__(self, game, x,y):
        #self.image = pygame.image.load("Player_Sprite_R.png")
        self.game=game
        self._layer=PLAYER_LAYER+1
        self.width=TILESIZE
        self.height=TILESIZE
        
        self.image=pygame.Surface([self.width, self.height])
        self.image.fill(BLACK)
        image_to_load=pygame.image.load("New Piskel 2.png")
        self.groups= self.game.all_sprites, self.game.bouncer
        pygame.sprite.Sprite.__init__(self, self.groups)
        # Position and direction
        self.x=x*TILESIZE
        self.y=y*TILESIZE
        self.width=TILESIZE
        self.height=TILESIZE
        
        self.image.blit(image_to_load,(0,0))
        self.image.set_colorkey(BLACK)
        self.rect=self.image.get_rect()
        self.rect.x=self.x
        self.rect.y=self.y
    def update(self):
        pygame.display.update()
class Arrow(pygame.sprite.Sprite):
    def __init__(self, game, x,y):
        #self.image = pygame.image.load("Player_Sprite_R.png")
        self.game=game
        self._layer=PLAYER_LAYER+1
        image_to_load=pygame.image.load("New Piskel.png")
        self.groups= self.game.all_sprites, self.game.arrow
        pygame.sprite.Sprite.__init__(self, self.groups)
        # Position and direction
        self.x=x*TILESIZE
        self.y=y*TILESIZE
        self.width=TILESIZE
        self.height=TILESIZE
        self.image=pygame.Surface([self.width, self.height])
        self.image.blit(image_to_load,(0,0))
        self.image.set_colorkey(BLACK)
        #self.image.fill(RED_LIGHT)
        self.rect=self.image.get_rect()
        self.rect.x=self.x
        self.rect.y=self.y
        self.x_change=0
        self.y_change=0

    def update(self):
        self.movement()
        pygame.display.update()
        self.collide_bouncer()

        self.rect.x+=self.x_change
        self.rect.y+=self.y_change
        self.collide_detect('x')

        self.collide_enemy()
        self.collide_detect('y')
        if GAMEOVERSCORE[0]==0:
            self.kill()
    def collide_enemy(self):
        hits=pygame.sprite.spritecollide(self, self.game.enemies, False)
        if hits:
            Score.append("*")
            self.kill()
    def collide_bouncer(self):
        hits=pygame.sprite.spritecollide(self, self.game.bouncer, False)
        if hits:
            Score.append("*")
            if self.x_change!=0:
                self.x_change=-self.x_change
            if self.y_change!=0:
                self.y_change=-self.y_change
    def movement(self):
        keys=pygame.key.get_pressed()
        for event in pygame.event.get():
            if event.type==pygame.KEYDOWN:
                if event.key==pygame.K_s:
                    self.x_change+=BALLDIRECTIONX[0]*50
                    self.y_change-=BALLDIRECTIONY[0]*50


        left, right, middle=pygame.mouse.get_pressed()
        if right:
            self.x+=PLAYER_SPEED
        if left:
            if self.y_change>0:
                self.y_change+=ACCELERATION
            if self.x_change>0:
                self.x_change+=ACCELERATION
            if self.y_change<0:
                self.y_change-=ACCELERATION
            if self.x_change<0:
                self.x_change-=ACCELERATION
    def collide_detect(self,direction):
        
        if direction=='x':
            hits=pygame.sprite.spritecollide(self, self.game.blocks, False)
            if hits:
                Score.append(1)
                if self.x_change>0:
                    self.rect.x=hits[0].rect.left- self.rect.width
                if self.x_change<0:
                    self.rect.x=hits[0].rect.right
                self.x_change=0
 

        if direction=='y':
            hits=pygame.sprite.spritecollide(self, self.game.blocks, False)
            if hits:
              
                if self.y_change>0:
                    self.rect.y=hits[0].rect.top-self.rect.height
                if self.y_change<0:
                    self.rect.y=hits[0].rect.bottom
                self.y_change=0
class Arrow1(pygame.sprite.Sprite):
    def __init__(self, game, x,y):
        #self.image = pygame.image.load("Player_Sprite_R.png")
        self.game=game
        self._layer=PLAYER_LAYER+1
        image_to_loading=pygame.image.load("New Piskel.png")
        self.groups= self.game.all_sprites, self.game.arrow
        pygame.sprite.Sprite.__init__(self, self.groups)
        # Position and direction
        self.x=x*TILESIZE
        self.y=y*TILESIZE
        self.width=TILESIZE
        self.height=TILESIZE
        self.image=pygame.Surface([self.width, self.height])
        self.image.blit(image_to_loading,(0,0))
        self.image.set_colorkey(BLACK)
        #self.image.fill(RED_LIGHT)
        self.rect=self.image.get_rect()
        self.rect.x=self.x
        self.rect.y=self.y
        self.x_change=0
        self.y_change=0

    def update(self):
        self.movement()
        pygame.display.update()
        self.collide_bouncer()

        self.rect.x+=self.x_change
        self.rect.y+=self.y_change
        self.collide_detect('x')

        self.collide_enemy()
        self.collide_detect('y')
        if GAMEOVERSCORE[0]==0:
            self.kill()
    def collide_enemy(self):
        
        hits=pygame.sprite.spritecollide(self, self.game.enemies, False)
        if hits:
            WINCONDITION.insert(0,0)
            Score.append(1)
            self.kill()
  
    def collide_bouncer(self):
        hits=pygame.sprite.spritecollide(self, self.game.bouncer, False)
        if hits:
            Score.append(1)
            if self.x_change!=0:
                self.x_change=-self.x_change
            if self.y_change!=0:
                self.y_change=-self.y_change
    def movement(self):
        keys=pygame.key.get_pressed()
        for event in pygame.event.get():
            if event.type==pygame.KEYDOWN:
                if event.key==pygame.K_s:
                    self.x_change-=BALLDIRECTIONX[0]*50
                    self.y_change-=BALLDIRECTIONY[0]*50


        left, right, middle=pygame.mouse.get_pressed()
        if right:
            self.x+=PLAYER_SPEED
        if left:
            if self.y_change>0:
                self.y_change+=ACCELERATION
            if self.x_change>0:
                self.x_change+=ACCELERATION
            if self.y_change<0:
                self.y_change-=ACCELERATION
            if self.x_change<0:
                self.x_change-=ACCELERATION
    def collide_detect(self,direction):
        if direction=='x':
            hits=pygame.sprite.spritecollide(self, self.game.blocks, False)
            if hits:
                Score.append(1)
                if self.x_change>0:
                    self.rect.x=hits[0].rect.left- self.rect.width
                if self.x_change<0:
                    self.rect.x=hits[0].rect.right
                self.x_change=0
 

        if direction=='y':
            hits=pygame.sprite.spritecollide(self, self.game.blocks, False)
            if hits:
               
                if self.y_change>0:
                    self.rect.y=hits[0].rect.top-self.rect.height
                if self.y_change<0:
                    self.rect.y=hits[0].rect.bottom
                self.y_change=0

class Pen(pygame.sprite.Sprite):
    def __init__(self, game, x,y):
        #self.image = pygame.image.load("Player_Sprite_R.png")
        self.game=game
        self._layer=0
        self.groups=  self.game.pen
        pygame.sprite.Sprite.__init__(self, self.groups)
        # Position and direction
        
        self.x=x*TILESIZE
        self.y=y*TILESIZE
        self.width=10
        self.height=TILESIZE

        self.surface=pygame.Surface([640,480])
        self.image=pygame.Surface([self.width,self.height])

        left, right, middle=pygame.mouse.get_pressed()
        pygame.display.set_caption('Mouse Pos:')
        if left:
            mx,my=pygame.mouse.get_pos()
            screen=pygame.display.set_mode((640,480),display=0)
            self._layer=0
            self.image=pygame.draw.line(game.screen,(0,100,200), (32,32*7), (int(mx),int(my)), width=10 )
            self.image.fill(RED_LIGHT)
            pygame.display.set_caption('Mouse Pos:'+str(x)+str(y)+str(mx)+','+str(my))
        pygame.display.flip()

    def update(self):
        self.drawing(self.game, self.x,self.y)

    def drawing(self,game,x,y):
        self.game=game
        left, right, middle=pygame.mouse.get_pressed()
        pygame.display.set_caption('Mouse Pos:')
        if left:
            mx,my=pygame.mouse.get_pos()
            screen=pygame.display.set_mode((640,480),display=0)
            self._layer=0
            pygame.draw.line(game.screen,(0,100,200), (32,32*7), (int(mx),int(my)), width=10 )
            pygame.display.set_caption('Mouse Pos:'+str(x)+str(y)+str(mx)+','+str(my))
        pygame.display.flip()
class intro_screening(pygame.sprite.Sprite):
    def __init__(self,game,x,y):
        self.image=pygame.Surface((250,250))
        self.game=game
        self.groups= self.game.all_sprites, self.game.screening
        pygame.sprite.Sprite.__init__(self, self.groups)
        self.image.fill((250,250,150))
        self.rect=self.image.get_rect(center=(250,250))
        myfont = pygame.font.SysFont('arial', 25)
        label = myfont.render("PL'AIM'ING GOLF", 1, (5,3,2))
        self.image.blit(label, (50,100))
        mouse=pygame.mouse.get_pressed()
        if mouse[0]:
            self.kill()
    def update(self):

        self.rect.center=pygame.mouse.get_pos()
        mouse=pygame.mouse.get_pressed()
        if mouse[0]:
            self.kill()

class score_table(pygame.sprite.Sprite):
    def __init__(self, game,x,y):
        self.image=pygame.Surface((125,250))
        self.game=game
        self.groups= self.game.all_sprites, self.game.scoring
        pygame.sprite.Sprite.__init__(self, self.groups)
        self.image.fill((250,250,150))
        self.rect=self.image.get_rect(center=(420,630))
        myfont = pygame.font.SysFont('arial', 25)
        myfont = pygame.font.SysFont('arial', 25)
    def labeling(self):
        myfont = pygame.font.SysFont('arial', 25)
        self.n=20-len(Score)
        label = myfont.render("Golfi_Molfi Score %.1f"%(self.n), 1, (5,3,2))
        return self.image.blit(label,(25,50))
    def update(self):

        self.image=pygame.Surface((250,125))
        self.image.fill((250,250,150))
        self.labeling()
        self.image.get_colorkey()
        self.n=20-len(Score)
        
        GAMEOVERSCORE.insert(0,self.n)
        pygame.display.update()
class gameover(pygame.sprite.Sprite):
    def __init__(self, game,x,y):
        
        self.image=pygame.Surface((100,70))
        self.game=game
        self.groups= self.game.all_sprites, self.game.gameovering
        pygame.sprite.Sprite.__init__(self, self.groups)
        self.rect=self.image.get_rect(center=(100,600))
        
        self.image.fill((250,250,150))
    
        
    def update(self):
        self.image=pygame.Surface((100,70))
        self.image.fill((250,250,150))
        font=pygame.font.SysFont("arial",20)
        if GAMEOVERSCORE[0]<=0:
            script="Game Over"
        elif GAMEOVERSCORE[0]>0:
            script="Level 1"

        label1 = font.render(script,2,(5,3,2))
        self.image.blit(label1,(15,30))
        pygame.display.flip()
class next_leveling(pygame.sprite.Sprite):
    def __init__(self, game,x,y):
        
        self.image=pygame.Surface((32*5,32))
        self.game=game
        self.groups= self.game.all_sprites, self.game.gameovering
        pygame.sprite.Sprite.__init__(self, self.groups)
        self.rect=self.image.get_rect(center=(800,624))
        
        self.image.fill((250,250,150))
    
        
    def update(self):
        self.image=pygame.Surface((32*5,32))
        self.image.fill((250,250,150))
        font=pygame.font.SysFont("arial",20)
        if WINCONDITION[0]<=0:
            script="Next Level"
        elif WINCONDITION[0]>0:
            script=""

        label1 = font.render(script,2,(5,3,2))
        self.image.blit(label1,(80,5))
        pygame.display.flip()
class Aimer(pygame.sprite.Sprite):
    def __init__(self, game,x,y):
        self.image=pygame.Surface((400,400))
        self.game=game
        self.groups= self.game.all_sprites, self.game.gameovering
        pygame.sprite.Sprite.__init__(self, self.groups)
        self.rect=self.image.get_rect(center=(400,400))
        
        self.image.fill((250,250,150))
    
        left, right, middle=pygame.mouse.get_pressed()
        if left:

                mx,my=pygame.mouse.get_pos()
            
                self._layer=PLAYER_LAYER
                
                pygame.display.set_caption('Mouse Pos:'+str(mx)+','+str(my))
                MOUSEPOS.append(my)
                MOUSEPOS1.append(mx)
                pos=WIN_WIDTH/2
                if MOUSEPOS1[len(MOUSEPOS)-1]>=pos:
                    pygame.draw.line(self.image,(0,100,200),(pos,32*(8)),(pos+60,my), width=10)
                if MOUSEPOS1[len(MOUSEPOS)-1]<pos:
                    pygame.draw.line(self.image,(0,100,200),(pos,32*(8)),(pos-60,my), width=10)
    def update(self):
        pygame.display.update()
    #HW,HH=WIN_WIDTH/2,WIN_HEIGHT/2
    #x,y =HW,HH
#    pmx,pmy=x,y
 #   dx,dy=0,0
  #  distance=0
   # speed=3
    #m=pygame.mouse.get_pressed()
    #if m[0] and not distance:
  #      mx,my=pygame.mouse.get_pos()
  #      radians=math.atan2(my-pmy,mx-pmx)
   #     distance=math.hypot(mx-pmx,my-pmy)/speed
    #    distance=int(distance)
     #   dx=math.cos(radians)*speed
      #  dy=math.sin(radians)*speed
       # pmx,pmy=mx,my
#    if distance:
  #      distance-=1
   #     x+=dx
    #    y+=dy
      #  pygame.draw.line(self.image,(0,0,0),(int(x),int(y)),(int(mx),int(my)))
    #pygame.draw.circle(self.image,(10,10,10),(int(x),int(y), 25)