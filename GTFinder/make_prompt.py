# -*- coding: utf-8 -*-

import  os
import  sys
sys.path.append(os.path.dirname(os.path.abspath(os.path.dirname(__file__))))

path    = "./"
files   = [
            "./Program.cs",
            "./FinderForm.cs", "./FinderForm.Designer.cs", 
            #"../MMenu/LayerMDay.h", "../MMenu/LayerMDay.cpp", 
            #"../MMenu/LayerMMonth.h", "../MMenu/LayerMMonth.cpp", 
            #"../MMenu/LayerMOption.h", "../MMenu/LayerMOption.cpp", 
            #"../engine/Seg7Disp.h", "../engine/Seg7Disp.cpp", 
            #"../engine/TimerDisp.h", "../engine/TimerDisp.cpp", 
            #"../engine/CardDisp.h", "../engine/CardDisp.cpp", 
            #"../engine/VideoNode.h", "../engine/VideoNode.cpp",
            #"../engine/AudioEngineAL.h", "../engine/AudioEngineAL.cpp",
        ]

out_file    = "./GTFinder_Prompt.txt"

# Use 'utf-8' for the output file for maximum compatibility.
# The 'with' statement ensures the file is automatically closed.
with open(out_file, 'w', encoding='utf-8') as o_f:
    for file in files:
        try:
            i_file  = os.path.join(path, file)
            # Use 'utf-8' to read the source files. This is the main fix.
            with open(i_file, "r", encoding='utf-8') as i_f:
                # 파일에 텍스트 쓰기
                #o_f.write(f"// ----- Start of file: {file} -----\n\n") # Optional: Add a header for clarity
                i_text  = i_f.read()
                o_f.write(i_text)
                o_f.write(f"\n\n") # Optional: Add a footer
                #o_f.write(f"\n\n// ----- End of file: {file} -----\n\n") # Optional: Add a footer
        except FileNotFoundError:
            print(f"Warning: File not found and will be skipped: {i_file}")
        except Exception as e:
            print(f"An error occurred while processing {file}: {e}")

    # This multi-line string with Korean characters will also be correctly written
    # because the output file is opened with 'utf-8'.
    o_f.write(
'''
무조건 대 전제를 잘 기억해서 꼭 반영해 (A,B,C)
A. 내가 준 소스를 참고해야해 
B. 변경없는 파일과 함수는 절대 출력하지 마,
C. 반드시 수정한 함수만 함수 구현부의 전체 코드를 카피 가능하게 어떠한 생략도 없이 가독성 있게 출력해야 해

** 아래 부터는 구체적인 요청 사항이야 
1. 
2. 
''')

print(f"Successfully created '{out_file}'")