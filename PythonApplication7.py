import cv2
from module1 import *
import numpy as np
import math
face_cascade = cv2.CascadeClassifier('cascade.xml')

# To capture video from webcam. 
cap = cv2.VideoCapture(0)
# To use a video file as input 
# cap = cv2.VideoCapture('filename.mp4')

while True:
    # Read the frame
    _, img = cap.read()
    font                   = cv2.FONT_HERSHEY_SIMPLEX
    bottomLeftCornerOfText = (100,100)
    fontScale              = 1
    fontColor              = (255,255,255)
    thickness              = 1
    lineType               = 2
    # Convert to grayscale
    gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    # Detect the faces
    faces = face_cascade.detectMultiScale(gray, 1.1, 4)
    # Draw the rectangle around each face
    for (x, y, w, h) in faces:
        cv2.rectangle(img, (x, y), (x+w, y+h), (255, 0, 0), 2)
        RECT_CENTER_X.append(x+(w/2))
        RECT_CENTER_Y.append(y+(h/2))
        x_new=RECT_CENTER_X[0]
        y_new=RECT_CENTER_Y[0]
        try:
            rel_distance_x=RECT_CENTER_X[len(RECT_CENTER_X)-1]-RECT_CENTER_X[0]
            rel_distance_y=RECT_CENTER_Y[len(RECT_CENTER_Y)-1]-RECT_CENTER_Y[0]
            if rel_distance_x**2+rel_distance_y**2>=8000:
                cv2.putText(img,'WELL DONE!!!', 

    bottomLeftCornerOfText, 
    font, 
    fontScale,
    fontColor,
    thickness,
    lineType)
        except: pass
    cv2.rectangle(img,(int(x_new),int(y_new)),(int(x_new+1),int(y_new+1)),(2,0,0),12)
   
    # Displayp
    cv2.imshow('img', img)

    # Stop if escape key is pressed
    k = cv2.waitKey(30) & 0xff
    if k==27:
 
        break
    
# Release the VideoCapture object
rel_distance_x=RECT_CENTER_X[len(RECT_CENTER_X)-1]-RECT_CENTER_X[0]
rel_distance_y=RECT_CENTER_Y[len(RECT_CENTER_Y)-1]-RECT_CENTER_Y[0]

print(rel_distance_x, rel_distance_y)
cap.release()
